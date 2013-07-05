using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Web.ViewModels
{
    public class AssessmentCompleteViewModel
    {
        public bool Passed { get; set; }
        public string Message { get; set; }
        public Transaction Transaction { get; set; }
        public decimal AffiliatedOtherFees { get; set; }
        public decimal ResWare1100MinusAffiliatedSettlement { get; set; }
        public decimal CapAmountMinusFeesTotal { get; set; }
    }
}