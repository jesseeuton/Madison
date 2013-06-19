using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Web.ViewModels
{
    public class AffiliateFeesViewModel
    {
        public int TransactionId { get; set; }
        public AffiliatedFees AffiliatedFee { get; set; }
        public decimal TotalAffiliatedFees { get; set; }
        public decimal LoanAmount { get; set; }
        
    }
}