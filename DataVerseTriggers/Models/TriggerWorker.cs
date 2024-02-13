using System.Collections.Generic;

namespace DataVerseTrigger.Models
{
    public class TriggerWorker
    {
        public List<DataVerseCloudFlow> LsDataVerseFlows { get; set; }
        public List<ScheduledCloudFlow> LsScheduledCloudFlows { get; set; }
        public List<ClassicWorkflow> LsClassicWorkflows { get; set; }
        public List<ManualCloudFlows> LsManualCloudFlows { get; set; }
    }
}
