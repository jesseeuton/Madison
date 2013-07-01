using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Business
{
    public class CapCalculatorOneHundred : ICapCalculator
    {
        public CapCalculationResult Calculate(CapCalculationResult capCalculationResult, decimal loanAmount)
        {
            decimal thresholdPercent = Convert.ToDecimal(.03);
            capCalculationResult.CapAmount = thresholdPercent * loanAmount;
            capCalculationResult.AmountRemainingUnderCap = capCalculationResult.CapAmount - capCalculationResult.CapCalculationResultInitial.Total;

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