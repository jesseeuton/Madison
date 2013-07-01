﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using Madison.Internal.QM.Web.Models;
using Madison.Internal.QM.Web.ViewModels;
using Madison.Internal.QM.Business;

using Madison.ResWare.Service;
using Madison.ResWare.Domain;

namespace Madison.Internal.QM.Web.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private TransactionContext db = new TransactionContext();

        public TransactionController()
        {

        }

        public ActionResult PropertyInfo()
        {
            BorrowerViewModel viewModel = new BorrowerViewModel();
            
            viewModel.PropertyTypes = db.PropertyTypes.ToList();
            viewModel.Property = TestModelBuilder.BuildPropertyInfoForTest();
            viewModel.Borrower = TestModelBuilder.BuildBorrowerForTest();

            return View("PropertyInfo", viewModel);
        }

        [HttpPost]
        public ActionResult PropertyInfo(BorrowerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                db.Borrowers.Add(viewModel.Borrower);
                db.Properties.Add(viewModel.Property);
                db.SaveChanges();

                Transaction transaction = new Transaction();
                transaction.UserProfileId = WebMatrix.WebData.WebSecurity.CurrentUserId;
                transaction.Borrower = viewModel.Borrower;
                transaction.Property = viewModel.Property;

                db.Transactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("TransactionInfo", new { transactionId = transaction.Id });
            }

            return View(viewModel);
        }

        public ActionResult TransactionInfo(int transactionId)
        {
            TransactionViewModel viewModel = new TransactionViewModel();
            viewModel.Endorsements = db.Endorsements.ToList();
            viewModel.InterestTypes = db.InterestTypes.ToList();
            viewModel.LoanTypes = db.LoanTypes.ToList();
            viewModel.TransactionTypes = db.TransactionTypes.ToList();
            viewModel.TransactionId = transactionId;

            return View("TransactionInfo", viewModel);
        }

        [HttpPost]
        public ActionResult TransactionInfo(TransactionViewModel viewModel)
        {
            //TODO:  Save the model
            if (ModelState.IsValid)
            {
                Transaction transaction = db.Transactions.Find(viewModel.TransactionId);
                transaction.LoanAmount = viewModel.Transaction.LoanAmount;
                transaction.SalePrice = viewModel.Transaction.SalePrice;
                transaction.UnpaidPrincipalAmount = viewModel.Transaction.UnpaidPrincipalAmount;
                transaction.OriginalDebtAmount = viewModel.Transaction.UnpaidPrincipalAmount;

                transaction.TransactionTypeId = viewModel.Transaction.TransactionType.Id;
                transaction.InterestTypeId = viewModel.Transaction.InterestType.Id;
                transaction.LoanTypeId = viewModel.Transaction.LoanType.Id;
                //transaction.Endorsements = viewModel.Transaction.Endorsements;

                db.SaveChanges();

                return RedirectToAction("AffiliatedFees", new { transactionId = transaction.Id, loanAmount = viewModel.Transaction.LoanAmount } );    
            }

            return View(viewModel);
        }

        public ActionResult AffiliatedFees(int transactionId, decimal loanAmount)
        {
            AffiliateFeesViewModel viewModel = new AffiliateFeesViewModel();
            viewModel.TransactionId = transactionId;
            viewModel.LoanAmount = loanAmount;

            return View("AffiliatedFees", viewModel);
        }

        
        [HttpPost]
        public ActionResult AffiliatedFees(AffiliateFeesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                db.AffiliatedFees.Add(viewModel.AffiliatedFee);
                db.SaveChanges();

                Transaction transaction = db.Transactions.Find(viewModel.TransactionId);
                transaction.AffiliatedFee = viewModel.AffiliatedFee;
                
                db.SaveChanges();

                CalculationFacade facade = new CalculationFacade();
                CapCalculationResult capCalcResult = facade.CalculateAffiliatedFees(viewModel, viewModel.LoanAmount);

                db.CapCalculationResults.Add(capCalcResult);
                db.SaveChanges();

                transaction.CapCalculationResult = capCalcResult;

                db.SaveChanges();
                
                return RedirectToAction("ShowAffiliatedFeesCalculation", new { transactionId = transaction.Id });
            }

            return View(viewModel);
        }

        public ActionResult ShowAffiliatedFeesCalculation(int transactionId)
        {
            CapCalculationResultViewModel viewModel = new CapCalculationResultViewModel();

            Transaction transaction = db.Transactions.Find(transactionId);

            viewModel.CapCalculationResult = transaction.CapCalculationResult;
            viewModel.TransactionId = transactionId;

            return View("AffiliatedFeesCalculation", viewModel);
        }

        [HttpPost]
        public ActionResult ShowAffiliatedFeesCalculation(CapCalculationResultViewModel viewModel)
        {
            return RedirectToAction("PriorTransactionInfo", new { viewModel.TransactionId });
        }

        public ActionResult PriorTransactionInfo(int transactionId)
        {
            TransactionViewModel viewModel = new TransactionViewModel();
            viewModel.TransactionId = transactionId;
            
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult PriorTransactionInfo(TransactionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Transaction transaction = db.Transactions.Find(viewModel.TransactionId);
                transaction.BuyerPriorLenderPolicyAmount = viewModel.Transaction.BuyerPriorLenderPolicyAmount;
                transaction.BuyerPriorLenderPolicyAvailableAsProof = viewModel.Transaction.BuyerPriorLenderPolicyAvailableAsProof;
                transaction.BuyerPriorLenderPolicyDate = viewModel.Transaction.BuyerPriorLenderPolicyDate;
                transaction.BuyerPriorOwnerPolicyAmount = viewModel.Transaction.BuyerPriorOwnerPolicyAmount;
                transaction.BuyerPriorOwnerPolicyAvailableAsProof = viewModel.Transaction.BuyerPriorOwnerPolicyAvailableAsProof;
                transaction.BuyerPriorOwnerPolicyDate = viewModel.Transaction.BuyerPriorOwnerPolicyDate;
                transaction.BuyerUnpaidBalance = viewModel.Transaction.BuyerUnpaidBalance;
                transaction.BuyerUnpaidBalanceOfPriorLoan = viewModel.Transaction.BuyerUnpaidBalanceOfPriorLoan;

                transaction.SellerPriorLenderPolicyAmount = viewModel.Transaction.SellerPriorLenderPolicyAmount;
                transaction.SellerPriorLenderPolicyAvailableAsProof = viewModel.Transaction.SellerPriorLenderPolicyAvailableAsProof;
                transaction.SellerPriorLenderPolicyDate = viewModel.Transaction.SellerPriorLenderPolicyDate;
                transaction.SellerPriorOwnerPolicyAmount = viewModel.Transaction.SellerPriorOwnerPolicyAmount;
                transaction.SellerPriorOwnerPolicyAvailableAsProof = viewModel.Transaction.SellerPriorOwnerPolicyAvailableAsProof;
                transaction.SellerPriorOwnerPolicyDate = viewModel.Transaction.SellerPriorOwnerPolicyDate;
                transaction.SellerUnpaidBalance = viewModel.Transaction.SellerUnpaidBalance;
                transaction.SellerUnpaidBalanceOfPriorLoan = viewModel.Transaction.SellerUnpaidBalanceOfPriorLoan;

                db.SaveChanges();

                //Call ResWare Fee Service to do the final calc
                EstimateFeesServiceFacade reswareFacade = new EstimateFeesServiceFacade();
                FeeEstimateRequest request = new FeeEstimateRequest();
                request.City = transaction.Property.City;
                request.ClientID = transaction.UserProfile.PartnerCompanyId;
                request.County = transaction.Property.County;
                request.LoanAmount = transaction.LoanAmount;
                request.OfficeID = transaction.UserProfile.OfficeId;
                request.OriginalDebtAmount = transaction.OriginalDebtAmount ?? 0;
                request.ProductTypeID = transaction.TransactionType.ResWareProductTypeId;
                request.SalesPrice = transaction.SalePrice ?? 0;
                request.State = transaction.Property.State;
                request.TransactionTypeID = transaction.TransactionType.ResWareTransactionTypeId;
                request.UnpaidPrincipalAmount = transaction.UnpaidPrincipalAmount ?? 0;
               
                ResWare.Service.EstimateFeesService.EstimateFeesResponse response = reswareFacade.GetFeeEstimate(request);

                //This needs some work and needs to be moved out.
                FeeEstimateResult result;
                if (response.HUDFees == null)
                {
                    result = new FeeEstimateResult();
                    result.WasSuccessful = false;
                    result.Message = response.Message;
                }
                else
                {
                    IList<Models.Fee> fees = new List<Models.Fee>();
                    response.HUDFees.ToList().ForEach(reswareFee =>
                    {
                        Models.Fee fee = new Models.Fee();
                        fee.Amount = reswareFee.Amount;
                        fee.HudLine = reswareFee.HUDLine;
                        fee.HudLineDescription = reswareFee.HUDLineDescription;

                        fees.Add(fee);
                    });

                    result = new FeeEstimateResult(fees, true, string.Empty);
                }

                db.FeeEstimateResults.Add(result);
                db.SaveChanges();

                transaction.FeeEstimateResult = result;
                db.SaveChanges();

                return RedirectToAction("AssessmentComplete", new { transactionId = transaction.Id });
            }

            return View(viewModel);
        }

        public ActionResult AssessmentComplete(int transactionId)
        {
            AssessmentCompleteViewModel viewModel = new AssessmentCompleteViewModel();
            StringBuilder messageBuilder = new StringBuilder();

            //Get the final calculation.
            Transaction transaction = db.Transactions.Find(transactionId);
            viewModel.Transaction = transaction;

            decimal capAmount = viewModel.Transaction.CapCalculationResult.CapAmount;
            decimal initialFees = viewModel.Transaction.CapCalculationResult.CapCalculationResultInitial.Total;
            decimal finalFees = viewModel.Transaction.FeeEstimateResult.GetTotalFeeAmount();

            if (capAmount > (initialFees + finalFees))
            {
                viewModel.Passed = true;
                messageBuilder.AppendLine("Based on your data input, this transaction has <b>PASSED</b> the initial QM analysis.");
                messageBuilder.AppendLine("Click to send data results and premium calculations to Affiliate.");
                viewModel.Message = messageBuilder.ToString();
            }
            else
            {
                viewModel.Passed = false;
                messageBuilder.AppendLine("Based on your data input, this transaction has <b>FAILED</b> the initial QM analysis.");
                messageBuilder.AppendLine("Click to send to Madison Settlement Services.");
                viewModel.Message = messageBuilder.ToString();
            }

            return View("AssessmentComplete", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        #region Dead Code
        ////
        //// GET: /Transaction/
        //public ActionResult Index()
        //{
        //    return View(db.Transactions.ToList());
        //}

        ////
        //// GET: /Transaction/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Transaction transaction = db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        ////
        //// GET: /Transaction/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Transaction/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Transactions.Add(transaction);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(transaction);
        //}

        ////
        //// GET: /Transaction/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Transaction transaction = db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        ////
        //// POST: /Transaction/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(transaction).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(transaction);
        //}

        ////
        //// GET: /Transaction/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Transaction transaction = db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        ////
        //// POST: /Transaction/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Transaction transaction = db.Transactions.Find(id);
        //    db.Transactions.Remove(transaction);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        #endregion  
    }
}