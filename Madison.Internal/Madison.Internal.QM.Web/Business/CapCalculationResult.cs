using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Business
{
    public class CapCalculationResult
    {
        public AffiliatedFeesCalculationResult AffiliatedFeesResult { get; set; }
        public PriorFeesResult PriorFeesResult { get; set; }
        public bool UnderCap { get; set; }

        [DataType(DataType.Currency)]
        public decimal CapAmount { get; set; }
        [DataType(DataType.Currency)]
        public decimal AmountRemainingUnderCap { get; set; }

        public CapCalculationResult()
        {
        }
    }
}