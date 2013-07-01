using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Madison.ResWare.Domain;

namespace Madison.ResWare.Service
{
    public class EstimateFeesServiceFacade : IEstimateFeesServiceFacade
    {
        private const int RESPONSE_CODE_SUCCESS = 0;

        public EstimateFeesServiceFacade() { }

        public FeeEstimateResult GetFeeEstimate(FeeEstimateRequest feeEstimate)
        {
            EstimateFeesService.EstimateFeesServiceClient client = new EstimateFeesService.EstimateFeesServiceClient();
            EstimateFeesService.EstimateFeesResponse response = client.EstimateFees(
                feeEstimate.ClientID,
                feeEstimate.OfficeID,
                feeEstimate.TransactionTypeID,
                feeEstimate.ProductTypeID,
                feeEstimate.City,
                feeEstimate.County,
                feeEstimate.State,
                feeEstimate.LoanAmount,
                feeEstimate.SalesPrice,
                feeEstimate.OriginalDebtAmount,
                feeEstimate.UnpaidPrincipalAmount);

            //for now assume we got a response.  
            //TODO:  Handle any response and bubble back
            if (response.ResponseCode != RESPONSE_CODE_SUCCESS)
            {
                return new FeeEstimateResult(null, false, response.Message);
            }

            IList<Fee> fees = new List<Fee>();
            response.HUDFees.ToList().ForEach(fee => fees.Add(new Fee(fee.Amount, fee.HUDLine, fee.HUDLineDescription)));

            return new FeeEstimateResult(fees, true, string.Empty);
        }

    }
}