using System;
using System.ComponentModel;

namespace DataVerseTrigger.Models
{
    public class CommonAutomation
    {
        [Browsable(true)]                         // this property should be visible
        [ReadOnly(true)]                          // but just read only
        [Description("")]             // sample hint1
        [Category("Generic")]                 // Category that I want
        [DisplayName("Workflow ID")]
        public Guid Workflowid { get; set; }
        [Browsable(true)]                         
        [ReadOnly(true)]                       
        [Description("")]          
        [Category("Generic")]                 
        [DisplayName("Workflow Unique ID")]
        public Guid Workflowuniqueid { get; set; }
        [Browsable(false)]
        public int Status { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Generic")]
        [DisplayName("Status")]
        public string StatusName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Generic")]
        [DisplayName("Name")]
        public string Name { set; get; }
    }
}
