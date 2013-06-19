using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.ResWare.Domain
{
    public class Fee
    {
        public decimal Amount { get; set; }
        public string HudLine { get; set; }
        public string HudLineDescription { get; set; }

        public Fee() { }

        public Fee(decimal amount, string hudLine, string hudLineDescription) 
        {
            Amount = amount;
            HudLine = hudLine;
            HudLineDescription = hudLineDescription;
        }
    }
}
