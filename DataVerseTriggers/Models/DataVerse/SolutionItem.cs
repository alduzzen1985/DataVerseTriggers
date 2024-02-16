using System;

namespace DataVerseTrigger.Models
{
    public class SolutionItem
    {
        public Guid SolutionId { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
