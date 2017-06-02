﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenQubit.PaymentGateway.Presentation.Web.Controllers
{
    public class ResponceController : Controller
    {
        private PaymentGatewayContext db = new PaymentGatewayContext();

        // GET: Responces
        public ActionResult Index()
        {
            var responce = db.Responce.Include(i => i.Request);
            return View(responce.ToList());
        }

        // GET: Responces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadResponce);
            }
            Responce responce = db.Responce.Find(id);
            if (responce == null)
            {
                return HttpNotFound();
            }
            return View(responce);
        }

        // GET: Responces/Create
        public ActionResult Create()
        {
            ViewBag.RequestID = new SelectList(db.Request, "Id","CreaditCardNo","CreaditCardCCV","CreaditCardName","ExpiaryDate","Amount","RequestTime","IPAddress","MerchantID");
            return View();
        }

        // POST: Responces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,status,MessageDetails,RespondTime,RequestId")] Responce responce)
        {
            if (ModelState.IsValid)
            {
                db.Responce.Add(responce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestID = new SelectList(db.Request, "Id", "CreaditCardNo", "CreaditCardCCV", "CreaditCardName", "ExpiaryDate", "Amount", "RequestTime", "IPAddress", "MerchantID", responce.RequestID);
            return View(responce);
        }

        // GET: Responces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadResponce);
            }
            Responce responce = db.Responce.Find(id);
            if (responce == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestID = new SelectList(db.Request, "Id", "CreaditCardNo", "CreaditCardCCV", "CreaditCardName", "ExpiaryDate", "Amount", "RequestTime", "IPAddress", "MerchantID", responce.RequestID);
            return View(responce);
        }

        // POST: Responces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,status,MessageDetails,RespondTime,RequestId")] Responce responce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestID = new SelectList(db.Request, "Id", "CreaditCardNo", "CreaditCardCCV", "CreaditCardName", "ExpiaryDate", "Amount", "RequestTime", "IPAddress", "MerchantID", responce.RequestID);
            return View(responce);
        }

        // GET: Responces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadResponce);
            }
            Responce responce = db.Responce.Find(id);
            if (responce == null)
            {
                return HttpNotFound();
            }
            return View(responce);
        }

        // POST: Responces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responce responce = db.Responce.Find(id);
            db.Responce.Remove(responce);
            db.SaveChanges();
            return RedirectToAction("Index");
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
