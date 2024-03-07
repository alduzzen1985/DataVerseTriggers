using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataVerseTrigger.Enums;
using DataVerseTrigger.Extensions;
using DataVerseTrigger.Models;
using DataVerseTrigger.Models.CloudFlows;

namespace DataVerseTrigger.Controls.Grids
{
    public partial class ManualTriggerCloudFlows : BaseControl
    {
        private List<ManualCloudFlow> lsManualCloudFlows;
        public List<ManualCloudFlow> LstScheduledCloudFlows
        {
            get => lsManualCloudFlows;
            set
            {
                filtersManual1.LstManualFlows = lsManualCloudFlows = value;
            }
        }



        public ManualTriggerCloudFlows()
        {
            InitializeComponent();
        }


        public void RefreshGrid()
        {
            dtGridScheduled.DataSource = lsManualCloudFlows;
            dtGridScheduled.Refresh();
        }

        private void dtGridScheduled_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGridScheduled.SelectedRows.Count == 1)
            {
                ManualCloudFlow selectedRow = dtGridScheduled.SelectedRows[0].DataBoundItem as ManualCloudFlow;
                propertyGrid1.SelectedObject = selectedRow;
            }
        }


        private void dtGridScheduled_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            var flowRun = (ManualCloudFlow)dtGridScheduled.Rows[e.RowIndex].DataBoundItem;

            switch (dtGridScheduled.Columns[e.ColumnIndex].Name)
            {
                case "Name":
                    SelectProcess(flowRun.Workflowuniqueid, ProcessType.CloudFlow);
                    break;
            }
        }

        private void dtGridScheduled_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            var flow = (ManualCloudFlow)dtGridScheduled.Rows[e.RowIndex].DataBoundItem;
            var column = dtGridScheduled.Columns[e.ColumnIndex];
            var columnName = column.Name;

            if (flow != null && columnName == "Status")
            {
                e.CellStyle.ForeColor = flow.Status == 2 ? Color.Green : Color.Red;
            }


        }

        private void filtersManual1_OnFilterApplied(List<ManualCloudFlow> LstManualFlows)
        {
            dtGridScheduled.DataSource = LstManualFlows;
            dtGridScheduled.Refresh();
        }
    }
}
