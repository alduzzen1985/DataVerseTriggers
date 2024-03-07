using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerseTrigger.Models.CloudFlows
{
    public class ManualCloudFlow : CommonAutomation
    {

        [Browsable(false)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Generic")]
        [DisplayName("Inputs")]
        public CloudFlowInputs[] Inputs { set; get; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Generic")]
        [DisplayName("Kind")]
        public string Kind { set; get; }
    }
}
