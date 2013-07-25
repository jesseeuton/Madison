using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Web.ViewModels
{
    public class DebtIncomeViewModel
    {
        public DebtIncome DebtIncome { get; set; }
        public decimal TotalMonthlyIncome { get; set; }
        public decimal TotalMonthlyObligations { get; set; }
        public decimal TotalMonthlyObligationsAndPMI { get; set; }
        public decimal DebtToIncomePercentage { get; set; }
    }
}