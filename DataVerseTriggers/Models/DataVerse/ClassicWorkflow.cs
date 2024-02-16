using System;
using System.ComponentModel;
using DataVerseTrigger.Enums;

namespace DataVerseTrigger.Models
{
    public class ClassicWorkflow : CommonAutomation
    {
      
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("On Create")]
        public bool TriggerOnCreate { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("On Delete")]
        public bool TriggerOnDelete { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Update attribute List")]

        public String TriggerOnUpdateAttributeList { get; set; }

   


        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Mode")]
        public Mode Mode { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Table Logical Name")]
        public string Primaryentityname { get; set; }

        [Browsable(false)]
        public WorkflowScope Scope { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Scope")]
        public string ScopeName { get; set; }

        [Browsable(false)]
        public bool OnDemand { get; set; }


        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("On Demand ?")]
        public string OnDemandName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("On assign")]
        public bool TriggerOnAssign { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("On status change")]
        public bool TriggerOnStatusChange { get; set; }


        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("As Child Process")]
        public bool AsChildProcess { get; set; }


        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("On update")]
        public bool TriggerOnUpdate { get; set; }
    }
}
