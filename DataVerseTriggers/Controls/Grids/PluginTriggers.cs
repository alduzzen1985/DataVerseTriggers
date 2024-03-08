using System;
using System.Drawing;
using System.Windows.Forms;
using DataVerseTrigger.Helper;
using DataVerseTrigger.Models;
using Microsoft.Xrm.Sdk;

namespace DataVerseTrigger.Controls.Grids
{
    public partial class PluginTriggers : UserControl
    {
        private IOrganizationService _service;
        private Plugin[] lstPlugins;


        public BindingItem[] PluginMessages
        {
            set { filterPlugins1.PluginMessages = value; }
        }

        public PowerAppsTable[] PowerAppsTables
        {
            set { filterPlugins1.PowerAppsTables = value; }
        }

        public Plugin[] LstPlugins
        {
            get => lstPlugins; set
            {
                lstPlugins = value;

            }
        }

        public IOrganizationService Service
        {
            set
            {
                filterPlugins1.Service = value;
                _service = value;
            }
            get
            {
                return _service;
            }
        }

        public Guid SolutionId { set; get; }

        public PluginTriggers()
        {
            InitializeComponent();
            filterPlugins1.OnFilterApplied += FilterPlugins1_OnFilterApplied;
        }

        private void FilterPlugins1_OnFilterApplied(int? tableObjectTypeCode, Guid[] messages, int[] stages, int[] executionMode, string[] attributes)
        {

            gtGridPlugins.DataSource = LstPlugins = PluginHelper.GetPlugins(Service, SolutionId, tableObjectTypeCode, messages, stages, executionMode, attributes);
            gtGridPlugins.Refresh();
        }


        public void RefreshGrid()
        {
            gtGridPlugins.DataSource = LstPlugins = PluginHelper.GetPlugins(Service, SolutionId);
            gtGridPlugins.Refresh();
        }

        private void dtGridDataVerse_SelectionChanged(object sender, EventArgs e)
        {
            if (gtGridPlugins.SelectedRows.Count == 1)
            {
                Plugin selectedRow = gtGridPlugins.SelectedRows[0].DataBoundItem as Plugin;
                propertyGrid1.SelectedObject = selectedRow;
            }
        }

        private void gtGridPlugins_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var flow = (Plugin)gtGridPlugins.Rows[e.RowIndex].DataBoundItem;
            var column = gtGridPlugins.Columns[e.ColumnIndex];
            var columnName = column.Name;

            if (flow != null && columnName == "Status")
            {
                e.CellStyle.ForeColor = flow.ComponentState == 0 ? Color.Green : Color.Red;
            }
        }
    }
}
