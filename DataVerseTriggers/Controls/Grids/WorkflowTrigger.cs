using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataVerseTrigger.Enums;
using DataVerseTrigger.Extensions;
using DataVerseTrigger.Helper;
using DataVerseTrigger.Models;
using Microsoft.Xrm.Sdk;

namespace DataVerseTrigger.Controls.Grids
{
    public partial class WorkflowTrigger : BaseControl
    {
        private IOrganizationService _service;
        public Guid SolutionId { set; get; }
        public IOrganizationService Service
        {
            set
            {
                _service = value;
                filterWorkflows1.Service = value;

            }
            get
            {
                return _service;
            }
        }

        private List<ClassicWorkflow> lsClassicWorkflows;

        public PowerAppsTable[] PowerAppsTables
        {
            set { filterWorkflows1.PowerAppsTables = value; }
        }

        public List<ClassicWorkflow> LsClassicWorkflows { get => lsClassicWorkflows; set => lsClassicWorkflows = value; }

        public WorkflowTrigger()
        {
            InitializeComponent();

        }


        public void RefreshGrid()
        {
            LsClassicWorkflows = WorkflowHelper.GetWorkflows(Service, SolutionId);
            dtWorkflows.DataSource = LsClassicWorkflows;
            dtWorkflows.Refresh();
        }





        private void dtWorkflows_SelectionChanged(object sender, EventArgs e)
        {
            if (dtWorkflows.SelectedRows.Count == 1)
            {
                ClassicWorkflow selectedRow = dtWorkflows.SelectedRows[0].DataBoundItem as ClassicWorkflow;

                propertyGrid1.SelectedObject = selectedRow;


            }
        }

        private void filterWorkflows1_OnFilterApplied(bool triggeroncreate, bool triggerondelete, bool triggerOnUpdate, bool triggerOnAssign, bool onStatusChanged, string[] attributesOnUpdate, Mode[] modes, Scope[] scopes, int? tableObjectCode, bool isOnDemand)
        {

            dtWorkflows.DataSource = WorkflowHelper.GetWorkflowsByFilters(Service, SolutionId, triggeroncreate,
                triggerondelete, triggerOnUpdate,
                triggerOnAssign, onStatusChanged, attributesOnUpdate, modes, scopes,
                tableObjectCode, isOnDemand);
            dtWorkflows.Refresh();
        }


        private void dtWorkflows_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            var flowRun = (ClassicWorkflow)dtWorkflows.Rows[e.RowIndex].DataBoundItem;

            switch (dtWorkflows.Columns[e.ColumnIndex].Name)
            {
                case "Name":
                    SelectProcess(flowRun.Workflowid, ProcessType.Workflow);
                    break;
            }
        }

        private void dtWorkflows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var flow = (ClassicWorkflow)dtWorkflows.Rows[e.RowIndex].DataBoundItem;
            var column = dtWorkflows.Columns[e.ColumnIndex];
            var columnName = column.Name;


            if (flow != null && columnName == "Status")
            {
                e.CellStyle.ForeColor = flow.Status == 2 ? Color.Green : Color.Red;

            }
        }
    }
}
