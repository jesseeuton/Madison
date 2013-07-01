using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Web.ViewModels
{
    public class CapCalculationResultViewModel
    {
        public int TransactionId { get; set; }
        public CapCalculationResult CapCalculationResult { get; set; }
    }
}