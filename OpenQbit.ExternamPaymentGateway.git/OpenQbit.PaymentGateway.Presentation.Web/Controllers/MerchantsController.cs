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
    public class MerchantsController : Controller
    {
        private PaymentGatewayContext db = new PaymentGatewayContext();

        // GET: Merchants
        public ActionResult Index()
        {
            return View(db.Merchant.ToList());
        }

        public ActionResult SearchByName(string namePart)
        {
            List<Merchant> merchantList = db.Merchant.Where(C => C.MerchantName.Contains(namePart)).ToList();
            return View(merchantList);
        }

        // GET: Merchants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchant merchant = db.Merchant.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        // GET: Merchants/Details/5
        public ActionResult Details2(int? id)
        {
            if (id == null)
            {
                return null;
            }
            Merchant merchant = db.Merchant.Find(id);
            if (merchant == null)
            {
                return null;
            }

            return Json(merchant, JsonRequestBehavior.AllowGet);
        }


        // GET: Merchants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Merchants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MerchantName")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                db.Merchant.Add(merchant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(merchant);
        }

        // GET: Merchants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchant merchant = db.Merchant.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        // POST: Merchants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MerchantName")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(merchant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(merchant);
        }

        // GET: Merchants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchant merchant = db.Merchant.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        // POST: Merchants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Merchant merchant = db.Merchant.Find(id);
            db.Merchant.Remove(merchant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetList()
        {
            Merchant[] merchantArry = db.Merchant.ToList().ToArray();

            return Json(merchantArry, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index2()
        {
            return View(db.Merchant.ToList());
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
