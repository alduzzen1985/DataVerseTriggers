using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataVerseTrigger.Enums;
using DataVerseTrigger.Extensions;
using DataVerseTrigger.Models;
using Microsoft.Xrm.Sdk;

namespace DataVerseTrigger.Controls.Grids
{
    public partial class ScheduledTrigger : BaseControl
    {
        private List<ScheduledCloudFlow> lsScheduledCloudFlows;
        public List<ScheduledCloudFlow> LstScheduledCloudFlows
        {
            get => lsScheduledCloudFlows; set
            {
                lsScheduledCloudFlows = value;
                filtersScheduled1.LstScheduledCloudFlows = value;
            }
        }

        public IOrganizationService Service
        {
            set
            {
                filtersScheduled1.Service = value;

            }
            get { return filtersScheduled1.Service; }
        }



        public ScheduledTrigger()
        {
            InitializeComponent();

        }

        private void FiltersScheduled1_OnFilterApplied(List<ScheduledCloudFlow> LstScheduledCloudFlows)
        {
            throw new NotImplementedException();
        }

        public void RefreshGrid()
        {
            dtGridScheduled.DataSource = lsScheduledCloudFlows;
            dtGridScheduled.Refresh();
        }

        private void dtGridScheduled_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGridScheduled.SelectedRows.Count == 1)
            {
                ScheduledCloudFlow selectedRow = dtGridScheduled.SelectedRows[0].DataBoundItem as ScheduledCloudFlow;


                propertyGrid1.SelectedObject = selectedRow;
            }
        }

        private void filtersScheduled1_OnFilterApplied(List<ScheduledCloudFlow> LstScheduledCloudFlows)
        {
            dtGridScheduled.DataSource = LstScheduledCloudFlows;
            dtGridScheduled.Refresh();
        }

        private void dtGridScheduled_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            var flowRun = (ScheduledCloudFlow)dtGridScheduled.Rows[e.RowIndex].DataBoundItem;

            switch (dtGridScheduled.Columns[e.ColumnIndex].Name)
            {
                case "Name":
                    SelectProcess(flowRun.Workflowuniqueid, ProcessType.CloudFlow);
                    break;
            }
        }

        private void dtGridScheduled_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            var flow = (ScheduledCloudFlow)dtGridScheduled.Rows[e.RowIndex].DataBoundItem;
            var column = dtGridScheduled.Columns[e.ColumnIndex];
            var columnName = column.Name;

            if (flow != null && columnName == "Status")
            {
                e.CellStyle.ForeColor = flow.Status == 2 ? Color.Green : Color.Red;
            }
        }

    }
}
