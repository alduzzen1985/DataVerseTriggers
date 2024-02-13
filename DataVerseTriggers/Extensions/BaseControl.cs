using System;
using System.Windows.Forms;
using DataVerseTrigger.Enums;
using XrmToolBox.Extensibility;

namespace DataVerseTrigger.Extensions
{
    
    public class BaseControl : PluginControlBase
    {
        public delegate void ProcessSelected(Guid processSelected, ProcessType processType);
        public event ProcessSelected OnProcessSelected;


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

    }
}
