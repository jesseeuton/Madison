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

namespace Madison.Internal.QM.Web.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private TransactionContext db = new TransactionContext();

        public TransactionController()
        {

        }

        public ActionResult BackToStepOne()
        {
            return View();
        }

        //public ActionResult PersonInfo()
        //{
        //    PersonViewModel personViewModel = new PersonViewModel();

        //    personViewModel.CompanyRelationships = db.CompanyRelationships.ToList();

        //    return View("PersonInfo", personViewModel);
        //}

        //[HttpPost]
        //public ActionResult PersonInfo(PersonViewModel viewModel)
        //{
        //    //TODO:  Save the view model
        //    Transaction transaction = new Transaction();
        //    if (ModelState.IsValid)
        //    {
        //        transaction.Person = viewModel.Person;
        //        db.Transactions.Add(transaction);
        //        db.SaveChanges();

        //        return RedirectToAction("PropertyInfo", new { transactionId = transaction.Id});
        //    }

        //    return View(viewModel);
        //}

        public ActionResult PropertyInfo()
        {
            BorrowerViewModel viewModel = new BorrowerViewModel();
            
            viewModel.PropertyTypes = db.PropertyTypes.ToList();

            return View("PropertyInfo", viewModel);
        }

        [HttpPost]
        public ActionResult PropertyInfo(BorrowerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Transaction transaction = new Transaction();
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
                transaction.InterestType = viewModel.Transaction.InterestType;
                transaction.LoanType = viewModel.Transaction.LoanType;
                transaction.Endorsements = viewModel.Transaction.Endorsements;

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
            //TODO:  save the model
            if (ModelState.IsValid)
            {
                Transaction transaction = db.Transactions.Find(viewModel.TransactionId);
                transaction.AffiliatedFee = viewModel.AffiliatedFee;
                
                db.SaveChanges();

                CalculationFacade facade = new CalculationFacade();
                CapCalculationResult capCalcResult = facade.CalculateAffiliatedFees(viewModel, viewModel.LoanAmount);

                TempData["CapCalcResult"] = capCalcResult;
                return RedirectToAction("ShowAffiliatedFeesCalculation", new { transactionId = transaction.Id });
            }

            return View(viewModel);
        }

        public ActionResult ShowAffiliatedFeesCalculation(int transactionId)
        {
            CapCalculationResult capCalcResult = TempData["CapCalcResult"] as CapCalculationResult;
            capCalcResult.TransactionId = transactionId;

            return View("AffiliatedFeesCalculation", capCalcResult);
        }

        [HttpPost]
        public ActionResult ShowAffiliatedFeesCalculation(CapCalculationResult capCalculationResult)
        {
            return RedirectToAction("PriorTransactionInfo", new { capCalculationResult.TransactionId });
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


                return RedirectToAction("AssessmentComplete", new { transactionId = transaction.Id });
            }

            return View(viewModel);
        }

        public ActionResult AssessmentComplete(int transactionId)
        {
            AssessmentCompleteViewModel viewModel = new AssessmentCompleteViewModel();
            StringBuilder messageBuilder = new StringBuilder();

            if (TempData["PassedQM"] != null && (bool)TempData["PassedQM"])
            {
                viewModel.Passed = true;
                messageBuilder.AppendLine("Based on your data input, this transaction has PASSED the initial QM analysis.");
                messageBuilder.AppendLine("Click to send data results and premium calculations to Affiliate.");
                viewModel.Message = messageBuilder.ToString();
            }
            else
            {
                viewModel.Passed = false;
                messageBuilder.AppendLine("Based on your data input, this transaction has FAILED the initial QM analysis.");
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