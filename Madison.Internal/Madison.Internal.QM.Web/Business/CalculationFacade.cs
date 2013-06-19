using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Madison.Internal.QM.Web.ViewModels;
 
namespace Madison.Internal.QM.Business
{
    public class CalculationFacade
    {
        
        public CalculationFacade() 
        {
        }

        public CapCalculationResult CalculateAffiliatedFees(AffiliateFeesViewModel affiliatedFees, decimal loanAmount)
        {
            AffiliatedFeesCalculationResult result = TotalAffiliatedFees(affiliatedFees);
            result.LoanAmount = loanAmount;
            CapCalculationResult capCalculationResult = CalculateCap(result);

            return capCalculationResult;
        }

        public CapCalculationResult CalculateCap(AffiliatedFeesCalculationResult affiliatedFeesResult)
        {
            CapCalculationResult capCalculation = new CapCalculationResult();
            capCalculation.AffiliatedFeesResult = affiliatedFeesResult;
            ICapCalculator calculator = CapCalculatorFactory.GetCapCalculator(affiliatedFeesResult.LoanAmount);

            calculator.Calculate(capCalculation);

            return capCalculation;
        }

        public AffiliatedFeesCalculationResult TotalAffiliatedFees(AffiliateFeesViewModel affiliatedFees)
        {
            AffiliatedFeesCalculationResult result = new AffiliatedFeesCalculationResult();

            if (IsValidField(affiliatedFees.AffiliatedFee.AppraisalFee))
            {
                result.Total += (decimal)affiliatedFees.AffiliatedFee.AppraisalFee;
                result.Summary.Add("Appraisal Fee: $" + affiliatedFees.AffiliatedFee.AppraisalFee);
            }

            if (IsValidField(affiliatedFees.AffiliatedFee.CreditFee))
            {
                result.Total += (decimal)affiliatedFees.AffiliatedFee.CreditFee;
                result.Summary.Add("Credit Fee: $" + affiliatedFees.AffiliatedFee.CreditFee);
            }

            if (IsValidField(affiliatedFees.AffiliatedFee.InspectionFee))
            {
                result.Total += (decimal)affiliatedFees.AffiliatedFee.InspectionFee;
                result.Summary.Add("Inspection Fee: $" + affiliatedFees.AffiliatedFee.InspectionFee);
            }

            if (IsValidField(affiliatedFees.AffiliatedFee.MortageOriginatorCompensationAmount))
            {
                result.Total += (decimal)affiliatedFees.AffiliatedFee.MortageOriginatorCompensationAmount;
                result.Summary.Add("Mortgage Originator Compensation Amount: $" + affiliatedFees.AffiliatedFee.MortageOriginatorCompensationAmount);
            }

            if (IsValidField(affiliatedFees.AffiliatedFee.NotaryFee))
            {
                result.Total += (decimal)affiliatedFees.AffiliatedFee.NotaryFee;
                result.Summary.Add("Notary Fee: $" + affiliatedFees.AffiliatedFee.NotaryFee);
            }

            if (IsValidField(affiliatedFees.AffiliatedFee.SurveyFee))
            {
                result.Total += (decimal)affiliatedFees.AffiliatedFee.SurveyFee;
                result.Summary.Add("Survey Fee: $" + affiliatedFees.AffiliatedFee.SurveyFee);
            }

            if (IsValidField(affiliatedFees.AffiliatedFee.TotalSettlementFee))
            {
                result.Total += (decimal)affiliatedFees.AffiliatedFee.TotalSettlementFee;
                result.Summary.Add("Total Settlement Fee: $" + affiliatedFees.AffiliatedFee.TotalSettlementFee);
            }

            if (IsValidField(affiliatedFees.AffiliatedFee.LenderFee))
            {
                result.Total += (decimal)affiliatedFees.AffiliatedFee.LenderFee;
                result.Summary.Add("Lender Fee: $" + affiliatedFees.AffiliatedFee.LenderFee);
            }

            return result;
        }

        private bool IsValidField(decimal? field)
        {
            if (field != null && field > 0)
            {
                return true;
            }

            return false;
        }
    }
}
