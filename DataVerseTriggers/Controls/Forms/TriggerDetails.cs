using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DataVerseTrigger.Helper.TriggerDB;

namespace DataVerseTrigger.Controls.Forms
{
    public partial class TriggerDetails : UserControl
    {
        public string DbPath { get; set; }
        public string EnvironmentId { get; set; }
        public string OrgBaseUrl { get; set; }
        public Action<string> OpenUrlAction { get; set; }

        private string _targetAutomationId;

        public TriggerDetails()
        {
            InitializeComponent();
            dgvCloudFlows.CellContentClick += (s, e) => HandleCellContentClick(dgvCloudFlows, e, isCloudFlow: true);
            dgvWorkflows.CellContentClick += (s, e) => HandleCellContentClick(dgvWorkflows, e, isCloudFlow: false);
        }

        public void LoadTriggersFor(string automationId)
        {
            _targetAutomationId = automationId;
            dgvCloudFlows.DataSource = null;
            dgvWorkflows.DataSource = null;
            tabPage1.Text = "Triggered by (Cloud Flows)";
            tabPage2.Text = "Triggered by (Classic Workflows)";

            if (string.IsNullOrEmpty(DbPath) || string.IsNullOrEmpty(automationId) || !File.Exists(DbPath))
                return;

            try
            {
                var db = new TriggerDatabaseManager(DbPath);
                var sources = db.GetTriggerSources(automationId);

                var cloudFlows = sources.Where(s => s.Category == 5).ToList();
                var workflows = sources.Where(s => s.Category == 0).ToList();

                dgvCloudFlows.DataSource = cloudFlows;
                dgvWorkflows.DataSource = workflows;

                tabPage1.Text = $"Triggered by Cloud Flows ({cloudFlows.Count})";
                tabPage2.Text = $"Triggered by Classic Workflows ({workflows.Count})";
            }
            catch { }
        }

        private void HandleCellContentClick(DataGridView grid, DataGridViewCellEventArgs e, bool isCloudFlow)
        {
            if (e.RowIndex < 0) return;
            var row = grid.Rows[e.RowIndex].DataBoundItem as TriggerSourceRow;
            if (row == null) return;

            var colName = grid.Columns[e.ColumnIndex].Name;
            var nameCol = isCloudFlow ? "colCfName" : "colWfName";
            var stepsCol = isCloudFlow ? "colCfViewSteps" : "colWfViewSteps";

            if (colName == nameCol)
                OpenInBrowser(row, isCloudFlow);
            else if (colName == stepsCol)
                ShowSteps(row);
        }

        private void OpenInBrowser(TriggerSourceRow row, bool isCloudFlow)
        {
            string url;
            if (isCloudFlow)
            {
                if (string.IsNullOrEmpty(row.UniqueId) || string.IsNullOrEmpty(EnvironmentId)) return;
                url = $"https://make.powerautomate.com/environments/{EnvironmentId}/flows/{row.UniqueId}/details";
            }
            else
            {
                if (string.IsNullOrEmpty(row.Id) || string.IsNullOrEmpty(OrgBaseUrl)) return;
                url = $"{OrgBaseUrl.TrimEnd('/')}/sfa/workflow/edit.aspx?id=%7b{row.Id}%7d";
            }
            try { OpenUrlAction?.Invoke(url); } catch { }
        }

        private void ShowSteps(TriggerSourceRow row)
        {
            if (string.IsNullOrEmpty(DbPath) || string.IsNullOrEmpty(_targetAutomationId) || string.IsNullOrEmpty(row.Id))
                return;
            try
            {
                var db = new TriggerDatabaseManager(DbPath);
                var steps = db.GetTriggerSteps(row.Id, _targetAutomationId);
                using (var form = new FormTriggerSteps(row.Name, steps))
                    form.ShowDialog(this);
            }
            catch { }
        }
    }
}
