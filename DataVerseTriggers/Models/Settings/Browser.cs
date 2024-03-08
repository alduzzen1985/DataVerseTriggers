using McTools.Xrm.Connection.WinForms;
using McTools.Xrm.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerseTrigger.Models
{
    public class Browser
    {
        public string Name { get; set; }
        public BrowserEnum Type { get; set; }
        public List<BrowserProfile> Profiles { get; set; }

        public string Executable { get; set; }
        public override string ToString() => Name;

    }
}