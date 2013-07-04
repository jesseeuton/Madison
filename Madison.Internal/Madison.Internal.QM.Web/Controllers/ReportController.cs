using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Madison.Internal.QM.Web.Models;
using Madison.Internal.QM.Web.ViewModels;

namespace Madison.Internal.QM.Web.Controllers
{
    public class ReportController : Controller
    {
        private TransactionContext db = new TransactionContext();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult QMATReport(int transactionId)
        {
            ReportViewModel viewModel = new ReportViewModel();
            viewModel.Transaction = db.Transactions.Find(transactionId);

            decimal capAmount = viewModel.Transaction.CapCalculationResult.CapAmount;
            decimal initialFees = viewModel.Transaction.CapCalculationResult.CapCalculationResultInitial.Total;
            decimal finalFees = viewModel.Transaction.FeeEstimateResult.GetTitlePremiumsAmount();


            viewModel.PassFailText = (capAmount - initialFees - finalFees) > 0 ? "PASS" : "FAIL";
            viewModel.MortgageTransferTaxPremium = viewModel.Transaction.FeeEstimateResult.GetMortgageTransferTaxAmount();
            viewModel.RecordingFees = viewModel.Transaction.FeeEstimateResult.GetRecordingFeeAmount();
            viewModel.SettlementFees = viewModel.Transaction.FeeEstimateResult.GetSettlementFeeAmount();
            viewModel.TitleInsurancePremium = viewModel.Transaction.FeeEstimateResult.GetTitlePremiumsAmount();
            viewModel.TotalFees = viewModel.MortgageTransferTaxPremium + viewModel.RecordingFees + viewModel.SettlementFees + viewModel.TitleInsurancePremium;

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}