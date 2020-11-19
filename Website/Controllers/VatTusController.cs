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
    public class VatTusController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: VatTus
        public ActionResult Index()
        {
            var vatTus = db.VatTus.Include(v => v.NCC);
            return View(vatTus.ToList());
        }

        // GET: VatTus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            return View(vatTu);
        }

        // GET: VatTus/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC");
            return View();
        }

        // POST: VatTus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVatTu,TenVatTu,DonGia,DonViTinh,MaNCC,HangSanXuat")] VatTu vatTu)
        {
            if (ModelState.IsValid)
            {
                db.VatTus.Add(vatTu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC", vatTu.MaNCC);
            return View(vatTu);
        }

        // GET: VatTus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC", vatTu.MaNCC);
            return View(vatTu);
        }

        // POST: VatTus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVatTu,TenVatTu,DonGia,DonViTinh,MaNCC,HangSanXuat")] VatTu vatTu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vatTu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC", vatTu.MaNCC);
            return View(vatTu);
        }

        // GET: VatTus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            return View(vatTu);
        }

        // POST: VatTus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VatTu vatTu = db.VatTus.Find(id);
            db.VatTus.Remove(vatTu);
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
