using System.ComponentModel;
using DataVerseTrigger.Enums;

namespace DataVerseTrigger.Models
{
    public class DataVerseCloudFlow : CommonAutomation
    {
       


        string entityname;
        MessageType message;
        Scope scope;
        string filteringattributes;
        string filterexpression;
        string postponeuntil;
        RunAs runas;


        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Table Logical Name")]
        public string Entityname { get => entityname; set => entityname = value; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Event / Message")]
        public MessageType Message { get => message; set => message = value; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Scope")]
        public Scope Scope { get => scope; set => scope = value; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Filtering Attributes")]
        public string Filteringattributes { get => filteringattributes; set => filteringattributes = value; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Filter Expression")]
        public string Filterexpression { get => filterexpression; set => filterexpression = value; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Postpone until")]
        public string Postponeuntil { get => postponeuntil; set => postponeuntil = value; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("")]
        [Category("Trigger")]
        [DisplayName("Run as")]
        public RunAs Runas { get => runas; set => runas = value; }
    }
}
