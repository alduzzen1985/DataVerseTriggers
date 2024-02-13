using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataVerseTrigger.Constants;
using DataVerseTrigger.Extensions;
using DataVerseTrigger.Models;

namespace DataVerseTrigger.Controls.Filters
{
    public partial class FiltersScheduled : BaseControl
    {
        public delegate void FilterApplied(List<ScheduledCloudFlow> LstScheduledCloudFlows);
        public event FilterApplied OnFilterApplied;

        public List<ScheduledCloudFlow> LstScheduledCloudFlows { set; get; }


        public FiltersScheduled()
        {
            InitializeComponent();

            chkWeekDays.DataSource = ComboValues.WEEKDAYS;
            chkWeekDays.DisplayMember = "Description";
            chkWeekDays.ValueMember = "Value";

            chkRecurrency.DataSource = ComboValues.FREQUENCY;
            chkRecurrency.DisplayMember = "Description";
            chkRecurrency.ValueMember = "Value";


        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (Service == null) return;


            var checkedItemsWeekDays = chkWeekDays.CheckedItems.OfType<BindingItem>().ToArray();
            var checkedItemsFrequency = chkRecurrency.CheckedItems.OfType<BindingItem>().ToArray();


            List<ScheduledCloudFlow> lstScheduledFlowsFiltered = LstScheduledCloudFlows;


            if (checkedItemsWeekDays.Length > 0)
            {
                lstScheduledFlowsFiltered = lstScheduledFlowsFiltered
                    .Where(x => checkedItemsWeekDays.Where(si => x.WeekDays.Contains(si.Value)).Any())
                .ToList();
            }


            if (checkedItemsFrequency.Length > 0)
            {
                lstScheduledFlowsFiltered = lstScheduledFlowsFiltered
                    .Where(x => checkedItemsFrequency.Where(si => si.Value == x.Frequency).Any())
                .ToList();
            }

           
            if (OnFilterApplied != null)
            {
                OnFilterApplied(lstScheduledFlowsFiltered);
            }
        }

        private void lnkClearFilters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ClearItemSelected(chkRecurrency);
            ClearItemSelected(chkWeekDays);
        }
    }
}
