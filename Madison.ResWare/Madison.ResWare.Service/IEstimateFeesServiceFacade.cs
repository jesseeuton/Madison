using System;
using Madison.ResWare.Domain;

namespace Madison.ResWare.Service
{
    public interface IEstimateFeesServiceFacade
    {
        FeeEstimateResult GetFeeEstimate(FeeEstimateRequest feeEstimate);
    }
}
