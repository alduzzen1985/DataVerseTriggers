using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataVerseTrigger.Constants;
using DataVerseTrigger.Extensions;
using DataVerseTrigger.Models;
using Microsoft.Xrm.Sdk;

namespace DataVerseTrigger.Controls.Filters
{
    public partial class FilterPlugins : BaseControl
    {
        private BindingItem[] messages;
        public BindingItem[] PluginMessages
        {
            set
            {
                messages = value;
                chkMessage.DataSource = messages;
                chkMessage.DisplayMember = "Description";
                chkMessage.ValueMember = "Value";
            }
        }


        private IOrganizationService _service;

        public delegate void FilterApplied(
            int? tableObjectTypeCode,
            Guid[] messages,
            int[] stages,
            int[] executionMode,
            string[] attributes

            );


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


        public FilterPlugins()
        {
            InitializeComponent();


            chkMessage.DataSource = messages;
            chkMessage.DisplayMember = "Description";
            chkMessage.ValueMember = "Value";

            chkLstMode.DataSource = ComboValues.PLUGIN_EXECUTION_MODE;
            chkLstMode.DisplayMember = "Description";
            chkLstMode.ValueMember = "Value";

            chkStage.DataSource = ComboValues.PLUGIN_STAGE;
            chkStage.DisplayMember = "Description";
            chkStage.ValueMember = "Value";

            attributesSelector1.Dock = DockStyle.Fill;


        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (Service == null) return;
            int? tableSelected = attributesSelector1.SelectedTableObjectTypeCode;
            string[] selectedAttributes = attributesSelector1.SelectedAttributes;

            var messageSelected = chkMessage.CheckedItems.OfType<BindingItem>().Select(x=> Guid.Parse(x.Value)).ToArray();
            var stagesSelected = chkStage.CheckedItems.OfType<BindingItem>().Select(x => Int32.Parse(x.Value)).ToArray();
            var selectedModes = chkLstMode.CheckedItems.OfType<BindingItem>().Select(x => Int32.Parse(x.Value)).ToArray();

            if (OnFilterApplied != null)
            {
                OnFilterApplied(tableSelected, messageSelected, stagesSelected, selectedModes, selectedAttributes);
            }

        }

        private void lnkClearFilters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ClearItemSelected(chkLstMode);
            ClearItemSelected(chkMessage);
            ClearItemSelected(chkStage);
            attributesSelector1.Clear();
        }
    }
}
