using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerseTrigger.Models.CloudFlows
{
    public class ManualCloudFlow : CommonAutomation
    {
        public CloudFlowInputs[] Inputs { set; get; }

        public string Kind { set; get; }
    }
}
