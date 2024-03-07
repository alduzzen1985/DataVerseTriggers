using System;
using System.Windows.Forms;
using DataVerseTrigger.Enums;
using Microsoft.Xrm.Sdk;
using XrmToolBox.Extensibility;

namespace DataVerseTrigger.Extensions
{
    
    public class BaseControl : PluginControlBase
    {
        public delegate void ProcessSelected(Guid processSelected, ProcessType processType);
        public event ProcessSelected OnProcessSelected;
        private IOrganizationService _service;



        protected void SelectProcess(Guid processSelected, ProcessType processType)
        {
            if (OnProcessSelected != null) OnProcessSelected(processSelected, processType);
        }

        protected void ClearItemSelected(CheckedListBox chk)
        {
            for (int i = 0; i < chk.Items.Count; i++)
            {
                chk.SetItemChecked(i, false);
            }
        }


        
        public IOrganizationService Service
        {
            set
            {
                _service = value;

            }
            get { return _service; }
        }

    }
}
