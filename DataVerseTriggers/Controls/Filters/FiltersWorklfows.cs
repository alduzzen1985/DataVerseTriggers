using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataVerseTrigger.Constants;
using DataVerseTrigger.Enums;
using DataVerseTrigger.Extensions;
using DataVerseTrigger.Models;
using Microsoft.Xrm.Sdk;

namespace DataVerseTrigger.Controls.Filters
{
    public partial class FilterWorkflows : BaseControl
    {
        private IOrganizationService _service;

        public delegate void FilterApplied(string name, bool triggeroncreate,
            bool triggerondelete,
            bool triggerOnUpdate,
            bool triggerOnAssign,
            bool onStatusChanged,
            string[] attributesOnUpdate,

            Mode[] modes,
            Scope[] scopes,
            int? tableObjectCode,
            bool isOnDemand);


        public event FilterApplied OnFilterApplied;

        public List<ClassicWorkflow> LstClassicWorkflows { set; get; }

        public IOrganizationService Service
        {
            set
            {
                _service = value;
                attributesSelector1.Service = value;
            }
            get
            {
                return _service;
            }
        }


        public PowerAppsTable[] PowerAppsTables
        {
            set
            {
                attributesSelector1.PowerAppsTables = value;
            }
        }


        public FilterWorkflows()
        {
            InitializeComponent();

            chkLstMode.DataSource = ComboValues.WORKFLOW_MODE;
            chkLstMode.DisplayMember = "Description";
            chkLstMode.ValueMember = "Value";

            chkEvents.DataSource = ComboValues.WORKFLOW_EVENTS;
            chkEvents.DisplayMember = "Description";
            chkEvents.ValueMember = "Value";

            chkScope.DataSource = ComboValues.SCOPE;
            chkScope.DisplayMember = "Description";
            chkScope.ValueMember = "Value";

            attributesSelector1.Dock = DockStyle.Fill;

        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (Service == null) return;

            var checkedItemsMessages = chkEvents.CheckedItems.OfType<BindingItem>().ToArray();
            var checkedItemsScope = chkScope.CheckedItems.OfType<BindingItem>().ToArray();
            var checkedItemsMode = chkLstMode.CheckedItems.OfType<BindingItem>().ToArray();

            bool isCreate = checkedItemsMessages.Where(x => x.Value == "Create").Any();
            bool isDelete = checkedItemsMessages.Where(x => x.Value == "Delete").Any();
            bool isAssign = checkedItemsMessages.Where(x => x.Value == "IsAssigned").Any();
            bool isStatusChange = checkedItemsMessages.Where(x => x.Value == "StatusChange").Any();

            Mode[] modes = checkedItemsMode.Select(i => (Mode)Enum.Parse(typeof(Mode), i.Value)).ToArray();

            Scope[] scopes = checkedItemsScope.Select(i => (Scope)Enum.Parse(typeof(Scope), i.Value)).ToArray();

            int? tableObjectCode = attributesSelector1.SelectedTableObjectTypeCode;

            if (OnFilterApplied != null)
            {
                OnFilterApplied(textBox1.Text, isCreate, isDelete, true, isAssign, isStatusChange, attributesSelector1.SelectedAttributes, modes, scopes, tableObjectCode, chkOnDemand.Checked);
            }

        }

        private void attributesSelector1_Load(object sender, EventArgs e)
        {

        }

        private void lnkClearFilters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            attributesSelector1.Clear();


            ClearItemSelected(chkEvents);
            ClearItemSelected(chkLstMode);
            ClearItemSelected(chkScope);

            chkOnDemand.Checked = false;
        }
    }
}
