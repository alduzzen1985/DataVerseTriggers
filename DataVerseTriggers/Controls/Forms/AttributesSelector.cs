using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataVerseTrigger.Helper;
using DataVerseTrigger.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace DataVerseTrigger.Controls.Forms
{
    public partial class AttributesSelector : UserControl
    {
        private IOrganizationService _service;
        private List<ListViewItem> LstAttributesSelected = new List<ListViewItem>();

        public string[] SelectedAttributes
        {
            get
            {
                return LstAttributesSelected.Select(x => x.Name).ToArray();
            }
        }

        public string SelectedTable
        {
            get
            {
                PowerAppsTable selectedTable = (PowerAppsTable)cmbTable.SelectedItem;
                return selectedTable != null ? selectedTable.LogicalName : null;
            }
        }




        public int? SelectedTableObjectTypeCode
        {
            get
            {
                PowerAppsTable selectedTable = (PowerAppsTable)cmbTable.SelectedItem;
                return selectedTable != null ? selectedTable.ObjectTypeCode : null;
            }
        }

        public PowerAppsTable[] PowerAppsTables
        {
            set
            {
                cmbTable.DataSource = value;
                cmbTable.DisplayMember = "DisplayName";
                cmbTable.ValueMember = "LogicalName";
            }
        }




        public IOrganizationService Service
        {
            set
            {
                _service = value;
            }
            get
            {
                return _service;
            }
        }


        public AttributesSelector()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void lnkSelectAttributes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PowerAppsTable selectedTable = (PowerAppsTable)cmbTable.SelectedItem;


            if (selectedTable != null && selectedTable.DisplayName != "-")
            {
                AttributeMetadata[] attributes = MetaDataHelper.GetListFieldsForEntity(Service, selectedTable.LogicalName);
                FormSelectAttributes formSelectAttributes = new FormSelectAttributes(Service, selectedTable.LogicalName, LstAttributesSelected);
                formSelectAttributes.OnAttributesSelected += FormSelectAttributes_OnAttributesSelected;
                formSelectAttributes.Show();
            }

        }



        private void FormSelectAttributes_OnAttributesSelected(List<ListViewItem> checkedAttributes)
        {
            LstAttributesSelected = checkedAttributes;
            lstAttributes.Items.Clear();
            lstAttributes.Items.AddRange(checkedAttributes.ToArray());
        }

        private void cmbTable_SelectedValueChanged(object sender, EventArgs e)
        {
            LstAttributesSelected.Clear();
            lstAttributes.Items.Clear();
        }

        private void AttributesSelector_Load(object sender, EventArgs e)
        {
            this.Height = Parent.Height;
            this.Width = Parent.Width;
            this.AutoSize = true;
        }


        public void Clear()
        {
            cmbTable.SelectedIndex= -1;
            LstAttributesSelected.Clear();
        }
    }
}
