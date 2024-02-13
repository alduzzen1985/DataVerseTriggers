using System;
using System.ComponentModel;

namespace DataVerseTrigger.Models
{
    public class Plugin
    {
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Entity / Table name")]
        public string PrimaryObjectTypeCode { get; set; }



        public Guid SdkMessageProcessingStepId { get; set; }
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Plugin step name")]
        public string Name { get; set; }


        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Message")]
        public string SdkMessageIdName { get; set; }


        [Browsable(false)]
        public int ComponentState { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Status")]
        public string ComponentStateName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Filtering Attributes")]
        public string FilteringAttributes { get; set; }

        [Browsable(false)]
        [ReadOnly(true)]
        public int Mode { get; set; }


        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Excecution Mode")]
        public string ModeName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Message Id")]
        public Guid SdkMessageId { get; set; }


        [Browsable(false)]
        public string SdkMessageFilterIdName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Stage Number")]
        public int Stage { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Stage Name")]
        public string StageName { get; set; }
    }

}