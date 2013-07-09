using System;
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
                transaction.OriginalDebtAmount = viewModel.Transaction.OriginalDebtAmount;

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

            decimal resware1100Fees = viewModel.Transaction.FeeEstimateResult.Get1100Fees();

            //Subtract the affiliated Settlement from our 1100 fees and add the 1100 fees + total appraisal fees and subtract from the cap.
            //Oh yeah, move this out of the controller.
            decimal affiliatedSettlementFee = 0;
            //decimal affiliatedTPO = 0; //add this to the settlement total?
            //decimal affiliatedPMI = 0; //add this to the settlement total?

            viewModel.AffiliatedOtherFees = 0;
            if (viewModel.Transaction.CapCalculationResult.CapCalculationResultInitial.Total != null)
            {
                if (viewModel.Transaction.AffiliatedFee.TotalSettlementFee != null)
                {
                    viewModel.AffiliatedOtherFees = (decimal)viewModel.Transaction.CapCalculationResult.CapCalculationResultInitial.Total - (decimal)viewModel.Transaction.AffiliatedFee.TotalSettlementFee;
                }
            }

            if (viewModel.Transaction.AffiliatedFee.TotalSettlementFee != null)
            {
                viewModel.ResWare1100MinusAffiliatedSettlement = resware1100Fees - (decimal)viewModel.Transaction.AffiliatedFee.TotalSettlementFee;
            }

            viewModel.CapAmountMinusFeesTotal = viewModel.Transaction.CapCalculationResult.CapAmount - (viewModel.Transaction.CapCalculationResult.CapCalculationResultInitial.Total + viewModel.ResWare1100MinusAffiliatedSettlement);
            
            if (viewModel.CapAmountMinusFeesTotal > 0)
            {
                viewModel.Passed = true;
                messageBuilder.AppendLine("Q-MAT AASESSMENT HAS PASSED. THIS FILE HAS BEEN SENT TO THE PRE-APPROVED PROVIDER IN ORDER TO ENSURE QM COMPLIANCE. THE QM ASSESSMENT REPORT HAS BEEN SENT TO THE LENDER.  WHILE YOUR LENDER WILL PERMIT YOUR CHOICE OF TITLE, THE USE OF THE APPROVED PROVIDER WILL ENHANCE YOUR SERVICE AND TURN TIME. PLEASE NOTIFY YOUR LENDER IMMEDIATELY OF YOUT TITLE VENDOR SELECTION BY CHOOSING AN OPTION BELOW.");
                viewModel.Message = messageBuilder.ToString();
            }
            else
            {
                //File passed, check the two possible scenarios
                viewModel.IsAffiliated = GetIsAffiliated(transaction.AffiliatedFee);
                viewModel.ResWareTitlePremiums = viewModel.Transaction.FeeEstimateResult.GetTitlePremiumsAmount();
                viewModel.Passed = false;

                if (viewModel.IsAffiliated)
                {
                    //Scenario1
                    if ((viewModel.Transaction.AffiliatedFee.TotalSettlementFee + viewModel.ResWareTitlePremiums) < resware1100Fees)
                    {
                        messageBuilder.AppendLine("Q-MAT ASSESSMENT HAS PASSED. THIS FILE HAS BEEN ASSIGNED TO THE PRE-APPROVED TITLE AND SETTLEMENT PROVIDER TO ENSURE QM COMPLIANCE. THE QM ASSESSMENT REPORT HAS BEEN SENT TO THE LENDER.  WHILE YOUR LENDER WILL PERMIT YOUR CHOICE OF TITLE, THE USE OF THE APPROVED PROVIDER WILL ENHANCE YOUR SERVICE AND TURN TIME. PLEASE NOTIFY YOUR LENDER IMMEDIATELY IF YOU ARE CHOOSING AN ALTERNATE TITLE AND SETTLEMENT VENDOR. CHANGES IN TITLE AND SETTLEMENT VENDOR SELECTION MAY NOT BE APPROVED BY THE LENDER IF NOT RECEIVED IMMEDIATELY VIA THE NOTFICATION CHANNEL PROVIDED BELOW.");
                        viewModel.Scenario1 = true;
                        viewModel.Message = messageBuilder.ToString();
                    }
                    else if ((viewModel.Transaction.AffiliatedFee.TotalSettlementFee + viewModel.ResWareTitlePremiums) > resware1100Fees)
                    {
                        messageBuilder.AppendLine("QMAT ASSESSMENT HAS FAILED. THIS FILE MUST BE REVIEWED BY THE LENDER. THE QM ASSESSMENT REPORT HAS BEEN SENT TO THE LENDER FOR REVIEW. A TITLE ORDER HAS NOT BEEN PLACED BECAUSE THE FILE CANNOT PASS AS SUBMITTED.");
                        viewModel.Scenario2 = true;
                        viewModel.Message = messageBuilder.ToString();
                    }
                    else
                    {
                        viewModel.Scenario4 = true;  //Failure across the board
                        
                        messageBuilder.AppendLine("BASED ON THE DATA YOUR PROVIDED THE INITIAL Q-MAT ANALYSIS HAS FAILED.");
                        viewModel.Message = messageBuilder.ToString();
                    }
                }
            }

            return View("AssessmentComplete", viewModel);
        }

        private bool GetIsAffiliated(AffiliatedFees affiliatedFees)
        {

            return true;
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