using System;

using Madison.ResWare.Domain;
using Madison.ResWare.Service.EstimateFeesService;

namespace Madison.ResWare.Service
{
    public interface IEstimateFeesServiceFacade
    {
        EstimateFeesResponse GetFeeEstimate(FeeEstimateRequest feeEstimate);
    }
}
