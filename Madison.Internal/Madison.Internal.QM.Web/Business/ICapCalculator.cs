using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Business
{
    public interface ICapCalculator
    {
        CapCalculationResult Calculate(CapCalculationResult capCalculation, decimal loanAmount);
    }
}