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

        public ActionResult QMATReport()
        {
            ReportViewModel viewModel = new ReportViewModel();
            viewModel.Transaction = db.Transactions.Find(36);

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

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            ReportModel reportmodel = db.ReportModels.Find(id);
            if (reportmodel == null)
            {
                return HttpNotFound();
            }
            return View(reportmodel);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReportModel reportmodel)
        {
            if (ModelState.IsValid)
            {
                db.ReportModels.Add(reportmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportmodel);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ReportModel reportmodel = db.ReportModels.Find(id);
            if (reportmodel == null)
            {
                return HttpNotFound();
            }
            return View(reportmodel);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReportModel reportmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportmodel);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ReportModel reportmodel = db.ReportModels.Find(id);
            if (reportmodel == null)
            {
                return HttpNotFound();
            }
            return View(reportmodel);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportModel reportmodel = db.ReportModels.Find(id);
            db.ReportModels.Remove(reportmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}