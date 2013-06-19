using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Madison.ResWare.Domain;

namespace Madison.ResWare.Service
{
    public class EstimateFeesServiceFacade
    {
        public EstimateFeesServiceFacade() { }

        public EstimateFeesService.EstimateFeesResponse GetFeeQuote(FeeEstimateRequest feeEstimate) 
        {
            EstimateFeesService.EstimateFeesServiceClient client = new EstimateFeesService.EstimateFeesServiceClient();
            return client.EstimateFees(
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
        }

    }
}
