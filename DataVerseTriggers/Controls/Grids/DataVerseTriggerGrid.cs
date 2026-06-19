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

        public string DbPath
        {
            set { triggerDetails1.DbPath = value; }
        }

        public string EnvironmentId
        {
            set { triggerDetails1.EnvironmentId = value; }
        }

        public string OrgBaseUrl
        {
            set { triggerDetails1.OrgBaseUrl = value; }
        }

        public System.Action<string> OpenUrlAction
        {
            set { triggerDetails1.OpenUrlAction = value; }
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
                triggerDetails1.LoadTriggersFor(selectedRow?.Workflowid.ToString());
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
    }
}
