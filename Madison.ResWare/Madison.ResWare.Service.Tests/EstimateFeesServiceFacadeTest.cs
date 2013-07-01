using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Madison.ResWare.Domain;
using Madison.ResWare.Service.EstimateFeesService;

namespace Madison.ResWare.Service.Tests
{
    [TestClass]
    public class EstimateFeesServiceFacadeTest
    {
        [TestMethod]
        public void GetFeesPurchase()
        {
            FeeEstimateRequest estimateRequest = new FeeEstimateRequest
            {
                ClientID = 2443,  //1st mariner Bank
                OfficeID = 1,
                TransactionTypeID = 3,  //Purchase
                ProductTypeID = 4,   //Purchase - Conventional - Mad EN
                City = "Boulder",
                State = "CO",
                County = "Boulder",
                LoanAmount = 150,
                SalesPrice = 3600
            };

            EstimateFeesServiceFacade facade = new EstimateFeesServiceFacade();

            FeeEstimateResult response = facade.GetFeeEstimate(estimateRequest);

            System.Diagnostics.Debug.WriteLine(response.FeeSummaryText);
            System.Diagnostics.Debug.WriteLine(response.TotalFeeAmount);

            Assert.IsNotNull(response);
            Assert.AreEqual(true, response.WasSuccessful);
        }

        [TestMethod]
        public void GetFeesRefi()
        {
            FeeEstimateRequest estimateRequest = new FeeEstimateRequest
            {
                ClientID = 2443,  //1st mariner Bank
                OfficeID = 1,
                TransactionTypeID = 2,  //Refi
                ProductTypeID = 7,   //Refinance = Conventional = Mad EN
                City = "Boulder",
                State = "CO",
                County = "Boulder",
                LoanAmount = 200000,
                //SalesPrice = 200000,
                OriginalDebtAmount = 200000,
                UnpaidPrincipalAmount = 180000
            };


            EstimateFeesServiceFacade facade = new EstimateFeesServiceFacade();

            FeeEstimateResult response = facade.GetFeeEstimate(estimateRequest);

            System.Diagnostics.Debug.WriteLine(response.FeeSummaryText);

            Assert.IsNotNull(response);
            Assert.AreEqual(true, response.WasSuccessful);
        }

        //Refinance TranID = 2
        //
    }
}
