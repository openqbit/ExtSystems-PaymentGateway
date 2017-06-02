using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenQbit.PaymentGateway.Common.Models;
using OpenQbit.PaymentGateway.DataAccess.DAL;

namespace OpenQbit.PaymentGateway.Presentation.Web.Controllers
{
    public class BanksController : Controller
    {
        private PaymentGatewayContext db = new PaymentGatewayContext();

        // GET: Banks
        public ActionResult Index()
        {
            return View(db.Bank.ToList());
        }

        public ActionResult SearchByName(string namePart)
        {
            List<Bank> bankList = db.Bank.Where(C => C.BankName.Contains(namePart)).ToList();
            return View(bankList);
        }

        // GET: Banks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Bank.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // GET: Bnaks/Details/5
        public ActionResult Details2(int? id)
        {
            if (id == null)
            {
                return null;
            }
            Bank bank = db.Bank.Find(id);
            if (bank == null)
            {
                return null;
            }

            return Json(bank, JsonRequestBehavior.AllowGet);
        }

        // GET: Banks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BankName,CreaditCardSequence")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Bank.Add(bank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bank);
        }

        // GET: Banks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Bank.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: Banks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BankName,CreaditCardSequence")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bank);
        }

        // GET: Banks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Bank.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bank bank = db.Bank.Find(id);
            db.Bank.Remove(bank);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetList()
        {
            Bank[] bankArry = db.Bank.ToList().ToArray();

            return Json(bankArry, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index2()
        {
            return View(db.Bank.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
