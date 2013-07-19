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

        //
        // GET: /DebtToIncome/

        public ActionResult Index()
        {
            var debttoincome = db.DebtToIncome.Include(d => d.EmploymentStatus).Include(d => d.EmploymentLength).Include(d => d.EmploymentLengthAtPriorCompany);
            return View(debttoincome.ToList());
        }

        //
        // GET: /DebtToIncome/Details/5

        public ActionResult Details(int id = 0)
        {
            DebtIncome debtincome = db.DebtToIncome.Find(id);
            if (debtincome == null)
            {
                return HttpNotFound();
            }
            return View(debtincome);
        }

        //
        // GET: /DebtToIncome/Create

        public ActionResult Create()
        {
            ViewBag.EmploymentStatusId = new SelectList(db.EmploymentStatus, "Id", "Name");
            ViewBag.EmploymentLengthId = new SelectList(db.EmploymentLength, "Id", "Name");
            ViewBag.EmploymentLengthAtPriorCompanyId = new SelectList(db.EmploymentLength, "Id", "Name");
            return View();
        }

        //
        // POST: /DebtToIncome/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DebtIncome debtincome)
        {
            if (ModelState.IsValid)
            {
                db.DebtToIncome.Add(debtincome);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmploymentStatusId = new SelectList(db.EmploymentStatus, "Id", "Name", debtincome.EmploymentStatusId);
            ViewBag.EmploymentLengthId = new SelectList(db.EmploymentLength, "Id", "Name", debtincome.EmploymentLengthId);
            ViewBag.EmploymentLengthAtPriorCompanyId = new SelectList(db.EmploymentLength, "Id", "Name", debtincome.EmploymentLengthAtPriorCompanyId);
            return View(debtincome);
        }

        //
        // GET: /DebtToIncome/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DebtIncome debtincome = db.DebtToIncome.Find(id);
            if (debtincome == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmploymentStatusId = new SelectList(db.EmploymentStatus, "Id", "Name", debtincome.EmploymentStatusId);
            ViewBag.EmploymentLengthId = new SelectList(db.EmploymentLength, "Id", "Name", debtincome.EmploymentLengthId);
            ViewBag.EmploymentLengthAtPriorCompanyId = new SelectList(db.EmploymentLength, "Id", "Name", debtincome.EmploymentLengthAtPriorCompanyId);
            return View(debtincome);
        }

        //
        // POST: /DebtToIncome/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DebtIncome debtincome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debtincome).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmploymentStatusId = new SelectList(db.EmploymentStatus, "Id", "Name", debtincome.EmploymentStatusId);
            ViewBag.EmploymentLengthId = new SelectList(db.EmploymentLength, "Id", "Name", debtincome.EmploymentLengthId);
            ViewBag.EmploymentLengthAtPriorCompanyId = new SelectList(db.EmploymentLength, "Id", "Name", debtincome.EmploymentLengthAtPriorCompanyId);
            return View(debtincome);
        }

        //
        // GET: /DebtToIncome/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DebtIncome debtincome = db.DebtToIncome.Find(id);
            if (debtincome == null)
            {
                return HttpNotFound();
            }
            return View(debtincome);
        }

        //
        // POST: /DebtToIncome/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DebtIncome debtincome = db.DebtToIncome.Find(id);
            db.DebtToIncome.Remove(debtincome);
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