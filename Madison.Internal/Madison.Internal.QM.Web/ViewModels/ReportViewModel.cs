using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Web.ViewModels
{
    public class ReportViewModel
    {
        public Transaction Transaction { get; set; }
        public string PassFailText { get; set; }
        public decimal TitleInsurancePremium { get; set; }
        public decimal MortgageTransferTaxPremium { get; set; }
        public decimal RecordingFees { get; set; }
        public decimal SettlementFees { get; set; }
        public decimal TotalFees { get; set; }
    }
}