using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace Automation_Analyzer
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager(string dbPath = "flowindex.db")
        {
            _connectionString = string.Format("Data Source={0};Version=3;", dbPath);
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public void InitializeDatabase()
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                // Drop legacy Flow-prefixed tables if they still exist from the old schema.
                // The new Automation-prefixed schema is not backwards-compatible (column names
                // and structure changed), so we drop and recreate — a --rebuild is required.
                var tables = conn.Query<string>(
                    "SELECT name FROM sqlite_master WHERE type='table'").ToList();
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

                    CREATE INDEX IF NOT EXISTS idx_triggers_entity      ON AutomationTriggers(EntityName);
                    CREATE INDEX IF NOT EXISTS idx_triggers_create       ON AutomationTriggers(TriggersOnCreate);
                    CREATE INDEX IF NOT EXISTS idx_triggers_update       ON AutomationTriggers(TriggersOnUpdate);
                    CREATE INDEX IF NOT EXISTS idx_triggers_delete       ON AutomationTriggers(TriggersOnDelete);
                    CREATE INDEX IF NOT EXISTS idx_trigger_attrs         ON AutomationTriggerAttributes(AutomationId);
                    CREATE INDEX IF NOT EXISTS idx_actions_entity        ON AutomationActions(EntityName);
                    CREATE INDEX IF NOT EXISTS idx_action_fields         ON AutomationActionFields(ActionId);
                    CREATE INDEX IF NOT EXISTS idx_dependencies_target   ON AutomationDependencies(TargetAutomationId);
                    CREATE INDEX IF NOT EXISTS idx_dependencies_source   ON AutomationDependencies(SourceAutomationId);
                ");
            }
        }
    }
}
