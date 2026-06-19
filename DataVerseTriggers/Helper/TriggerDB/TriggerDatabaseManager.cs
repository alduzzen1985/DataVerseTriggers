using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Dapper;

namespace DataVerseTrigger.Helper.TriggerDB
{
    public class TriggerDatabaseManager
    {
        private readonly string _connectionString;

        public static string GetDbPath(Guid connectionId, string connectionName)
        {
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "MscrmTools", "XrmToolBox", "AG.XTB.DataVerseTriggers", "DBTriggers");
            Directory.CreateDirectory(folder);

            var invalid = new HashSet<char>(Path.GetInvalidFileNameChars());
            string safeName = new string(connectionName.Select(c => invalid.Contains(c) ? '_' : c).ToArray());
            return Path.Combine(folder, $"{connectionId}-{safeName}.db");
        }

        public TriggerDatabaseManager(string dbPath)
        {
            _connectionString = $"Data Source={dbPath};Version=3;";
        }

        public SQLiteConnection GetConnection() => new SQLiteConnection(_connectionString);

        public void InitializeDatabase()
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                var tables = conn.Query<string>("SELECT name FROM sqlite_master WHERE type='table'").ToList();
                if (tables.Contains("Flows"))
                {
                    conn.Execute("DROP TABLE IF EXISTS FlowDependencies");
                    conn.Execute("DROP TABLE IF EXISTS FlowActions");
                    conn.Execute("DROP TABLE IF EXISTS FlowTriggers");
                    conn.Execute("DROP TABLE IF EXISTS Flows");
                }

                conn.Execute(@"
                    CREATE TABLE IF NOT EXISTS Automations (
                        Id              TEXT PRIMARY KEY,
                        Name            TEXT NOT NULL,
                        Category        INTEGER,
                        EnvironmentId   TEXT,
                        UniqueId        TEXT,
                        LastModified    DATETIME,
                        LastIndexed     DATETIME,
                        IsActive        INTEGER NOT NULL DEFAULT 1
                    );

                    CREATE TABLE IF NOT EXISTS AutomationTriggers (
                        AutomationId        TEXT PRIMARY KEY,
                        TriggerType         TEXT,
                        EntityName          TEXT,
                        TriggersOnCreate    INTEGER NOT NULL DEFAULT 0,
                        TriggersOnUpdate    INTEGER NOT NULL DEFAULT 0,
                        TriggersOnDelete    INTEGER NOT NULL DEFAULT 0,
                        FilterExpression    TEXT,
                        FOREIGN KEY (AutomationId) REFERENCES Automations(Id)
                    );

                    CREATE TABLE IF NOT EXISTS AutomationTriggerAttributes (
                        Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                        AutomationId    TEXT NOT NULL,
                        AttributeName   TEXT NOT NULL,
                        FOREIGN KEY (AutomationId) REFERENCES Automations(Id)
                    );

                    CREATE TABLE IF NOT EXISTS AutomationActions (
                        Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                        AutomationId    TEXT NOT NULL,
                        ActionName      TEXT,
                        ActionType      TEXT,
                        EntityName      TEXT,
                        Description     TEXT,
                        FOREIGN KEY (AutomationId) REFERENCES Automations(Id)
                    );

                    CREATE TABLE IF NOT EXISTS AutomationActionFields (
                        Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                        ActionId    INTEGER NOT NULL,
                        FieldName   TEXT NOT NULL,
                        FOREIGN KEY (ActionId) REFERENCES AutomationActions(Id)
                    );

                    CREATE TABLE IF NOT EXISTS AutomationDependencies (
                        Id                  INTEGER PRIMARY KEY AUTOINCREMENT,
                        SourceAutomationId  TEXT,
                        TargetAutomationId  TEXT,
                        MatchReason         TEXT,
                        Confidence          TEXT,
                        FOREIGN KEY (SourceAutomationId) REFERENCES Automations(Id),
                        FOREIGN KEY (TargetAutomationId) REFERENCES Automations(Id)
                    );

                    CREATE TABLE IF NOT EXISTS LastRefresh (
                        Id          INTEGER PRIMARY KEY DEFAULT 1,
                        RefreshedOn DATETIME NOT NULL
                    );

                    CREATE INDEX IF NOT EXISTS idx_triggers_entity    ON AutomationTriggers(EntityName);
");
                // Migrate existing DBs that pre-date the UniqueId column
                try { conn.Execute("ALTER TABLE Automations ADD COLUMN UniqueId TEXT"); } catch { }

                conn.Execute(@"
                    CREATE INDEX IF NOT EXISTS idx_triggers_create     ON AutomationTriggers(TriggersOnCreate);
                    CREATE INDEX IF NOT EXISTS idx_triggers_update     ON AutomationTriggers(TriggersOnUpdate);
                    CREATE INDEX IF NOT EXISTS idx_triggers_delete     ON AutomationTriggers(TriggersOnDelete);
                    CREATE INDEX IF NOT EXISTS idx_trigger_attrs       ON AutomationTriggerAttributes(AutomationId);
                    CREATE INDEX IF NOT EXISTS idx_actions_entity      ON AutomationActions(EntityName);
                    CREATE INDEX IF NOT EXISTS idx_action_fields       ON AutomationActionFields(ActionId);
                    CREATE INDEX IF NOT EXISTS idx_dependencies_target ON AutomationDependencies(TargetAutomationId);
                    CREATE INDEX IF NOT EXISTS idx_dependencies_source ON AutomationDependencies(SourceAutomationId);
                ");
            }
        }

        public DateTime? GetLastRefreshTime()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return conn.QueryFirstOrDefault<DateTime?>(
                    "SELECT RefreshedOn FROM LastRefresh WHERE Id = 1");
            }
        }

        public List<TriggerSourceRow> GetTriggerSources(string targetAutomationId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return conn.Query<TriggerSourceRow>(@"
                    SELECT a.Id, a.UniqueId, a.Name, a.Category, a.IsActive, d.MatchReason, d.Confidence
                    FROM AutomationDependencies d
                    JOIN Automations a ON a.Id = d.SourceAutomationId
                    WHERE d.TargetAutomationId = @targetAutomationId
                    ORDER BY a.Name",
                    new { targetAutomationId }).ToList();
            }
        }

        public List<TriggerStepRow> GetTriggerSteps(string sourceAutomationId, string targetAutomationId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return conn.Query<TriggerStepRow>(@"
                    SELECT aa.ActionName, aa.ActionType, aa.EntityName, aa.Description
                    FROM AutomationActions aa
                    JOIN AutomationTriggers at ON at.AutomationId = @targetId
                        AND at.EntityName = aa.EntityName
                    WHERE aa.AutomationId = @sourceId
                      AND (
                        (at.TriggersOnCreate = 1 AND aa.ActionType = 'CreateRecord')
                        OR (at.TriggersOnDelete = 1 AND aa.ActionType = 'DeleteRecord')
                        OR (at.TriggersOnUpdate = 1 AND aa.ActionType = 'UpdateRecord'
                            AND (
                                NOT EXISTS (
                                    SELECT 1 FROM AutomationTriggerAttributes ata
                                    WHERE ata.AutomationId = at.AutomationId
                                )
                                OR EXISTS (
                                    SELECT 1 FROM AutomationActionFields aaf
                                    JOIN AutomationTriggerAttributes ata
                                        ON ata.AutomationId = at.AutomationId
                                        AND ata.AttributeName = aaf.FieldName
                                    WHERE aaf.ActionId = aa.Id
                                )
                                OR NOT EXISTS (
                                    SELECT 1 FROM AutomationActionFields aaf
                                    WHERE aaf.ActionId = aa.Id
                                )
                            ))
                      )
                    ORDER BY aa.ActionName",
                    new { sourceId = sourceAutomationId, targetId = targetAutomationId }).ToList();
            }
        }

        public void SaveRefreshTime(DateTime time)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                conn.Execute(
                    "INSERT OR REPLACE INTO LastRefresh (Id, RefreshedOn) VALUES (1, @time)",
                    new { time });
            }
        }
    }
}
