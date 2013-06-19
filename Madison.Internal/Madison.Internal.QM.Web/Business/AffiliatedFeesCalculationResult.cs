using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Business
{
    public class AffiliatedFeesCalculationResult
    {
        public decimal Total { get; set; }
        public List<string> Summary { get; set; }
        public decimal LoanAmount { get; set; }

        public AffiliatedFeesCalculationResult()
        {
            Summary = new List<string>();
        }
    }
}