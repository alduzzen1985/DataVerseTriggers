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
    public partial class FiltersDataVerse : BaseControl
    {
        public delegate void FilterApplied(List<DataVerseCloudFlow> LstDataVerseTriggers);
        public event FilterApplied OnFilterApplied;

        public List<DataVerseCloudFlow> LstDataVerseTriggers { set; get; }


        public PowerAppsTable[] PowerAppsTables
        {
            set
            {
                attributesSelector1.PowerAppsTables = value;
            }
        }

        public IOrganizationService Service
        {
            set { attributesSelector1.Service = value; }
            get { return attributesSelector1.Service; }
        }


        public FiltersDataVerse()
        {
            InitializeComponent();

            chkMessages.DataSource = ComboValues.MESSAGE_TYPES;
            chkMessages.DisplayMember = "Description";
            chkMessages.ValueMember = "Value";

            chkScope.DataSource = ComboValues.SCOPE;
            chkScope.DisplayMember = "Description";
            chkScope.ValueMember = "Value";

            chkRunAs.DataSource = ComboValues.RUN_AS;
            chkRunAs.DisplayMember = "Description";
            chkRunAs.ValueMember = "Value";
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (this.Service == null) return;
            var checkedItemsMessages = chkMessages.CheckedItems.OfType<BindingItem>().ToArray();
            var checkedItemsScope = chkScope.CheckedItems.OfType<BindingItem>().ToArray();
            var checkedItemsRunAs = chkRunAs.CheckedItems.OfType<BindingItem>().ToArray();


            List<DataVerseCloudFlow> lstDataVerseTriggersFiltered = LstDataVerseTriggers;


            if (!string.IsNullOrEmpty(txtName.Text))
            {
                lstDataVerseTriggersFiltered = lstDataVerseTriggersFiltered.Where(x => x.Name.Contains(txtName.Text)).ToList();
            }

            if (checkedItemsMessages.Length > 0)
            {

                lstDataVerseTriggersFiltered = lstDataVerseTriggersFiltered
                    .Where(x => checkedItemsMessages.Where(si => int.Parse(si.Value) == (int)x.Message).Any())
                .ToList();
            }


            if (checkedItemsScope.Length > 0)
            {

                lstDataVerseTriggersFiltered = lstDataVerseTriggersFiltered
                    .Where(x => checkedItemsScope.Where(si => int.Parse(si.Value) == (int)x.Scope).Any())
                .ToList();
            }


            if (checkedItemsRunAs.Length > 0)
            {

                lstDataVerseTriggersFiltered = lstDataVerseTriggersFiltered
                    .Where(x => checkedItemsRunAs.Where(si => int.Parse(si.Value) == (int)x.Runas).Any())
                .ToList();
            }


            if (attributesSelector1.SelectedTable != "-")
            {
                lstDataVerseTriggersFiltered = lstDataVerseTriggersFiltered.Where(x => x.Entityname == attributesSelector1.SelectedTable).ToList();
            }

            

            if (!string.IsNullOrEmpty(txtFilterAttributes.Text))
            {
                lstDataVerseTriggersFiltered = lstDataVerseTriggersFiltered.Where(x => x.Filteringattributes.Contains(txtFilterAttributes.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(txtFilterExpression.Text))
            {
                lstDataVerseTriggersFiltered = lstDataVerseTriggersFiltered.Where(x => x.Filterexpression.Contains(txtFilterExpression.Text)).ToList();
            }

            if (OnFilterApplied != null)
            {
                OnFilterApplied(lstDataVerseTriggersFiltered);
            }
        }

        private void lnkClearFilters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

            attributesSelector1.Clear();
            txtFilterAttributes.Text = string.Empty;
            txtFilterExpression.Text = string.Empty;
            ClearItemSelected(chkMessages);
            ClearItemSelected(chkRunAs);
            ClearItemSelected(chkScope);

        }
    }
}
