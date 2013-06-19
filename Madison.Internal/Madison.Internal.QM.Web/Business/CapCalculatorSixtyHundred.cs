using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Business
{
    public class CapCalculatorSixtyHundred : ICapCalculator
    {
        public CapCalculationResult Calculate(CapCalculationResult capCalculationResult)
        {
            capCalculationResult.CapAmount = 3000;
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