using System;
using System.Collections.Generic;
using Madison.Internal.QM.Web.Models;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Controllers
{
    public class TestModelBuilder
    {
        public static Property BuildPropertyInfoForTest()
        {
            Property property = new Property();
            property.Address1 = "Address 1";
            property.Address2 = "Address 2";
            property.City = "Boulder";
            property.County = "Boulder";
            property.State = "CO";
            property.Zip = "80301";
            return property;
        }

        public static Borrower BuildBorrowerForTest()
        {
            Borrower borrower = new Borrower();
            borrower.FirstName = "Phil";
            borrower.LastName = "Gaimon";
            return borrower;
        }

        public static AffiliatedFees BuildAffiliatedFeesForTest()
        {
            AffiliatedFees fee = new AffiliatedFees();
            fee.AppraisalFee = 1;
            fee.CreditFee = 2;
            fee.InspectionFee = 3;
            //fee.LenderFeesTotal = 4;
            fee.NotaryFee = 5;
            fee.SurveyFee = 6;
            fee.TotalSettlementFee = 7;
            fee.NotaryFee = 89;
            return fee;
        }

        public static Transaction BuildTransactionForTest()
        {
            Transaction transaction = new Transaction();
            transaction.LoanAmount = 5;
            transaction.BuyerPriorLenderPolicyAmount = 4;
            transaction.BuyerPriorLenderPolicyDate = DateTime.Now;
            transaction.BuyerPriorOwnerPolicyAmount = 67;
            transaction.BuyerPriorOwnerPolicyDate = DateTime.Now.AddDays(-30);
            transaction.BuyerUnpaidBalance = 3;

            transaction.LoanAmount = 100000;
            transaction.SellerPriorLenderPolicyAmount = 14;
            transaction.SellerPriorLenderPolicyDate = DateTime.Now;
            transaction.SellerPriorOwnerPolicyAmount = 167;
            transaction.SellerPriorOwnerPolicyDate = DateTime.Now.AddDays(-30);
            transaction.SellerUnpaidBalance = 13;
            return transaction;
        }

        public static Person BuildPersonForTest()
        {
            Person person = new Person();
            person.CompanyName = "Madison";
            person.EmailAddress = "jimjones@noemail.com";
            person.FirstName = "Jason";
            person.LastName = "Briggs";
            person.Phone = "123-456-7890";

            return person;
        }
    }
}