using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class TonsController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: Tons
        public ActionResult Index()
        {
            var tons = db.Tons.Include(t => t.VatTu);
            return View(tons.ToList());
        }

        // GET: Tons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ton ton = db.Tons.Find(id);
            if (ton == null)
            {
                return HttpNotFound();
            }
            return View(ton);
        }

        // GET: Tons/Create
        public ActionResult Create()
        {
            ViewBag.MaVatTu = new SelectList(db.VatTus, "MaVatTu", "TenVatTu");
            return View();
        }

        // POST: Tons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,MaVatTu,SLTon")] Ton ton)
        {
            if (ModelState.IsValid)
            {
                db.Tons.Add(ton);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaVatTu = new SelectList(db.VatTus, "MaVatTu", "TenVatTu", ton.MaVatTu);
            return View(ton);
        }

        // GET: Tons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ton ton = db.Tons.Find(id);
            if (ton == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaVatTu = new SelectList(db.VatTus, "MaVatTu", "TenVatTu", ton.MaVatTu);
            return View(ton);
        }

        // POST: Tons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,MaVatTu,SLTon")] Ton ton)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ton).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaVatTu = new SelectList(db.VatTus, "MaVatTu", "TenVatTu", ton.MaVatTu);
            return View(ton);
        }

        // GET: Tons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ton ton = db.Tons.Find(id);
            if (ton == null)
            {
                return HttpNotFound();
            }
            return View(ton);
        }

        // POST: Tons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ton ton = db.Tons.Find(id);
            db.Tons.Remove(ton);
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
