using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Web.Controllers
{
    public class DebtToIncomeController : Controller
    {
        private TransactionContext db = new TransactionContext();

        public ActionResult DICalculator()
        {
            ViewBag.EmploymentStatusId = new SelectList(db.EmploymentStatus, "Id", "Name");
            ViewBag.EmploymentLengthId = new SelectList(db.EmploymentLength, "Id", "Name");
            ViewBag.EmploymentLengthAtPriorCompanyId = new SelectList(db.EmploymentLength, "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult DICalculator(DebtIncome debtIncome)
        {


            return RedirectToAction("Index", "Account");
        }

        
        ////
        //// POST: /DebtToIncome/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(DebtIncome debtincome)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.DebtToIncome.Add(debtincome);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.EmploymentStatusId = new SelectList(db.EmploymentStatus, "Id", "Name", debtincome.EmploymentStatusId);
        //    ViewBag.EmploymentLengthId = new SelectList(db.EmploymentLength, "Id", "Name", debtincome.EmploymentLengthId);
        //    ViewBag.EmploymentLengthAtPriorCompanyId = new SelectList(db.EmploymentLength, "Id", "Name", debtincome.EmploymentLengthAtPriorCompanyId);
        //    return View(debtincome);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}