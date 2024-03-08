using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataVerseTrigger.Helper;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace DataVerseTrigger.Controls.Forms
{
    public partial class FormSelectAttributes : Form
    {

        public delegate void AttributesSelected(List<ListViewItem> checkedAttributes);
        public event AttributesSelected OnAttributesSelected;

        private string entityLogicalName;
        private IOrganizationService service;
        private List<ListViewItem> checkedAttributes;
        private AttributeMetadata[] attributes;


        private bool selectAllAttributes = true;

        public FormSelectAttributes()
        {
            InitializeComponent();
        }

        public FormSelectAttributes(IOrganizationService service, string entityLogicalName, List<ListViewItem> checkedAttributes)
        {
            InitializeComponent();
            this.checkedAttributes = checkedAttributes;
            this.service = service;
            this.entityLogicalName = entityLogicalName;
            attributes = MetaDataHelper.GetListFieldsForEntity(service, entityLogicalName);
            FillGrid(txtSearchAttribute.Text);
            lstAttributes.ItemChecked += LstAttributes_ItemChecked;

        }

        private void FillGrid(string filter)
        {
            AttributeMetadata[] attributesList = attributes;
            lstAttributes.Items.Clear();

            List<ListViewItem> lstItem = new List<ListViewItem>();

            if (!string.IsNullOrEmpty(filter))
            {
                attributesList = attributes.Where(a => (a.LogicalName.Contains(filter) ||
                    (
                    a.DisplayName.LocalizedLabels.Count > 0 &&
                    a.DisplayName.LocalizedLabels.First().Label.Contains(filter))
                    )
                ).ToArray();
            }

            attributesList = attributesList.Where(a => a.DisplayName.LocalizedLabels.Count > 0).ToArray();

            foreach (AttributeMetadata attr in attributesList)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = attr.DisplayName.LocalizedLabels.First().Label,
                    Name = attr.LogicalName,
                    Checked = checkedAttributes.Where(cattr => attr.LogicalName == cattr.Name).Any()
                };

                item.SubItems.Add(attr.LogicalName);
                item.SubItems.Add(attr.AttributeTypeName.Value);
                lstItem.Add(item);
            }

            lstAttributes.Items.AddRange(lstItem.ToArray());
        }

        private void LstAttributes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem listViewItemChecked = checkedAttributes.Where(x => x.Name == e.Item.Name).FirstOrDefault();


            if (e.Item.Checked && listViewItemChecked == null)
            {
                ListViewItem n = (ListViewItem)e.Item.Clone();
                n.Name = e.Item.Name;
                checkedAttributes.Add(n);
            }

            if (!e.Item.Checked)
            {
                checkedAttributes.Remove(listViewItemChecked);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid(txtSearchAttribute.Text);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (OnAttributesSelected != null)
            {
                OnAttributesSelected(checkedAttributes);
                this.Close();
            }
        }

        private void txtSearchAttribute_KeyPress(object sender, KeyPressEventArgs e)
        {
            FillGrid(txtSearchAttribute.Text);
        }

        private void lnkSelectAttributesAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lstAttributes.Items)
            {
                if (selectAllAttributes && !item.Checked)
                {
                    item.Checked = selectAllAttributes;
                }

                if (!selectAllAttributes && item.Checked)
                {
                    item.Checked = selectAllAttributes;
                }

            }
            selectAllAttributes = !selectAllAttributes;

        }

        private void linkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lstAttributes.Items)
            {
                item.Checked = false;
            }
        }
    }
}
