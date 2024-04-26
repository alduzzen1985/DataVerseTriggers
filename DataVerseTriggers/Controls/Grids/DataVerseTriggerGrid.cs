using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using DataVerseTrigger.Enums;
using DataVerseTrigger.Extensions;
using DataVerseTrigger.Models;
using Microsoft.Xrm.Sdk;


namespace DataVerseTrigger.Controls.Grids
{
    public partial class DataVerseTriggerGrid : BaseControl
    {
        private List<DataVerseCloudFlow> lstDataVerseTriggers;


        public PowerAppsTable[] PowerAppsTables
        {
            set { dataVerseFilters1.PowerAppsTables = value; }
        }

        public List<DataVerseCloudFlow> LstDataVerseTriggers
        {
            get => lstDataVerseTriggers;
            set
            {
                lstDataVerseTriggers = value;
                dataVerseFilters1.LstDataVerseTriggers = value;
            }
        }

        public IOrganizationService Service
        {
            set { dataVerseFilters1.Service = value; }
        }

        public DataVerseTriggerGrid()
        {
            InitializeComponent();
            dataVerseFilters1.OnFilterApplied += DataVerseFilters1_filterApplied;
            dtGridDataVerse.DataError += DtGridDataVerse_DataError;
        }

        private void DtGridDataVerse_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void DataVerseFilters1_filterApplied(List<DataVerseCloudFlow> LstDataVerseTriggers)
        {
            dtGridDataVerse.DataSource = LstDataVerseTriggers;
        }

        public void RefreshGrid()
        {

            dtGridDataVerse.DataSource = null;
            
            BindingSource source = new BindingSource();
            source.DataSource = lstDataVerseTriggers;



            dtGridDataVerse.DataSource = source;
            dtGridDataVerse.Update();
            dtGridDataVerse.Refresh();
        }

        private void dtGridDataVerse_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGridDataVerse.SelectedRows.Count == 1)
            {
                DataVerseCloudFlow selectedRow = dtGridDataVerse.SelectedRows[0].DataBoundItem as DataVerseCloudFlow;
                propertyGrid1.SelectedObject = selectedRow;
            }
        }


        private void dtGridDataVerse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            var flowRun = (DataVerseCloudFlow)dtGridDataVerse.Rows[e.RowIndex].DataBoundItem;

            switch (dtGridDataVerse.Columns[e.ColumnIndex].Name)
            {
                case "NameCloudFlow":
                    SelectProcess(flowRun.Workflowuniqueid, ProcessType.CloudFlow);
                    break;
            }
        }

        private void dtGridDataVerse_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var flowRun = (DataVerseCloudFlow)dtGridDataVerse.Rows[e.RowIndex].DataBoundItem;

            if (flowRun.Status == 0)
            {

                e.CellStyle.ForeColor = Color.Red;
            }
            else
            {
                e.CellStyle.ForeColor = Color.Green;
            }





        }

        private void dtGridDataVerse_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dtGridDataVerse_DataSourceChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dtGridDataVerse.Rows)
            {
                var flow = (DataVerseCloudFlow)row.DataBoundItem;
                row.Cells["Status"].Style.ForeColor = flow.Status == 2 ? Color.Green : Color.Red;

            }

            //var flow = (DataVerseCloudFlow)dtGridDataVerse.Rows[e.RowIndex].DataBoundItem;
            //var column = dtGridDataVerse.Columns[e.ColumnIndex];
            //var columnName = column.Name;


            //if (flow != null && columnName == "Status")
            //{
            //    e.CellStyle.ForeColor = flow.Status == 2 ? Color.Green : Color.Red;

            //}
        }
    }
}
