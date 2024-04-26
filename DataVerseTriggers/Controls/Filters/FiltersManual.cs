using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using DataVerseTrigger.Constants;
using DataVerseTrigger.Extensions;
using DataVerseTrigger.Models;
using DataVerseTrigger.Models.CloudFlows;
using Microsoft.Xrm.Sdk;

namespace DataVerseTrigger.Controls.Filters
{
    public partial class FiltersManual : BaseControl
    {
        public delegate void FilterApplied(List<ManualCloudFlow> LstManualFlows);
        public event FilterApplied OnFilterApplied;

        public List<ManualCloudFlow> LstManualFlows { set; get; }

        private IOrganizationService _service;
        public IOrganizationService Service
        {
            set
            {
                _service = value;

            }
            get { return _service; }
        }



        public FiltersManual()
        {
            InitializeComponent();

            chkKind.DataSource = ComboValues.KIND;
            chkKind.DisplayMember = "Description";
            chkKind.ValueMember = "Value";


            chkStatus.DataSource = ComboValues.WF_STATUS;
            chkStatus.DisplayMember = "Description";
            chkStatus.ValueMember = "Value";

        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (LstManualFlows == null) return;

            var checkedItemsKinds = chkKind.CheckedItems.OfType<BindingItem>().ToArray();
            var checkedStateCodes = chkStatus.CheckedItems.OfType<BindingItem>().ToArray();



            List<ManualCloudFlow> lstScheduledFlowsFiltered = LstManualFlows;


            if (!string.IsNullOrEmpty(txtName.Text))
            {
                lstScheduledFlowsFiltered = lstScheduledFlowsFiltered.Where(x => x.Name.ToUpper().Contains(txtName.Text.ToUpper())).ToList();
            }

            if (checkedItemsKinds.Length > 0)
            {
                lstScheduledFlowsFiltered = lstScheduledFlowsFiltered
                    .Where(x => checkedItemsKinds.Where(si => x.Kind.Contains(si.Value)).Any())
                .ToList();
            }

            if (checkedStateCodes.Length > 0)
            {
                lstScheduledFlowsFiltered = lstScheduledFlowsFiltered
                    .Where(x => checkedStateCodes.Where(si => int.Parse(si.Value) == x.Status).Any())
                .ToList();
            }


            if (OnFilterApplied != null)
            {
                OnFilterApplied(lstScheduledFlowsFiltered);
            }
        }

        private void lnkClearFilters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtName.Text = string.Empty;
            ClearItemSelected(chkKind);
        }
    }
}
