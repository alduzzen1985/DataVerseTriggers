using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerseTrigger.Models
{
    public class BrowserProfile
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public override string ToString() => this.Name;
    }
}
