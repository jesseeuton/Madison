using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Internal.QM.Web.Models
{
    [Table("Fee")]
    public class Fee
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string HudLine { get; set; }
        public string HudLineDescription { get; set; }

        public Fee() { }
    }
}
