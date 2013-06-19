using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Business
{
    public class CapCalculatorOneHundred : ICapCalculator
    {
        public CapCalculationResult Calculate(CapCalculationResult capCalculationResult)
        {
            decimal thresholdPercent = Convert.ToDecimal(.03);
            capCalculationResult.CapAmount = thresholdPercent * capCalculationResult.AffiliatedFeesResult.LoanAmount;
            capCalculationResult.AmountRemainingUnderCap = capCalculationResult.CapAmount - capCalculationResult.AffiliatedFeesResult.Total;

            if (capCalculationResult.AmountRemainingUnderCap > 0)
            {
                capCalculationResult.UnderCap = true;
            }
            else
            {
                capCalculationResult.UnderCap = false;
            }

            return capCalculationResult;
            
        }
    }
}