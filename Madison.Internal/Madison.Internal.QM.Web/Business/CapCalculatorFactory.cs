using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Business
{
    public class CapCalculatorFactory
    {
        public static ICapCalculator GetCapCalculator(decimal loanAmount)
        {
            //for now all caps are calculated at 2.5%
            return new CapCalculatorOneHundred();

            //ICapCalculator calculator = null;
            //if (loanAmount >= 100000)
            //{
            //    calculator = new CapCalculatorOneHundred();
            //}
            //else if (loanAmount >= 60000 && loanAmount < 100000)
            //{
            //    calculator = new CapCalculatorSixtyHundred();
            //}
            //else if (loanAmount >= 20000 && loanAmount < 60000)
            //{
            //    calculator = new CapCalculatorTwentySixty();
            //}
            //else if (loanAmount >= 12500 && loanAmount < 20000)
            //{
            //    calculator = new CapCalculatorTwelveFiveTwenty();
            //}
            //else
            //{
            //    calculator = new CapCalculatorTwelveFive();
            //}

            //return calculator;
        }
    }
}