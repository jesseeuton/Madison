using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Madison.ResWare.Domain;
using Madison.ResWare.Service.EstimateFeesService;

namespace Madison.ResWare.Service.Tests
{
    [TestClass]
    public class UnitTest1
    {
//        Product ID 152 – Optimized Purchase COnv Team A
//Product ID 151 – Optimized Refinance Conv Team A
//Product ID – 153 – Optimized Reverse COnv Team A
        [TestMethod]
        public void TestMethod1()
        {
            int clientID = 2443;  //1st Mariner Bank
            int officeID = 1;
            int transactionTypeID = 3;  //Purchase
            int productTypeID = 152;  //3 Purchase - FHA - C:\Projects\Madison\LQB\Madison.ResWare.Domain\FeeEstimate.csM
            string city = "Baltimore";
            string county = "Baltimore City";
            string state = "MD";
            decimal loanAmount = 200000;
            decimal salesPrice = 200000;
            decimal origDebtAmount = 200000;
            decimal unpaidPrincipal = 180000;

         
            EstimateFeesServiceClient service = new EstimateFeesServiceClient();
            EstimateFeesResponse response = service.EstimateFees(clientID, officeID, transactionTypeID, productTypeID, city,
                county, state, loanAmount, salesPrice, origDebtAmount, unpaidPrincipal);

            Assert.IsNotNull(response);
            Assert.AreEqual(0, response.ResponseCode);
        }
    }
}
