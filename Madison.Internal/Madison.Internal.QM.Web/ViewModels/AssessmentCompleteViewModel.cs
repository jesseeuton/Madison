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
        public bool IsAffiliated { get; set; }
        public decimal ResWareTitlePremiums { get; set; } //1103, 1104, 1109
        public bool Scenario1 { get; set; }  //Affiliated Settlement + ResWare Title PRemiums < ResWare1100
        public bool Scenario2 { get; set; }  //Aff Sett + Res Tit Prem > ResWare1100
        public bool Scenario3 { get; set; }  //Pass
        public bool Scenario4 { get; set; }  //Failure
    }
}