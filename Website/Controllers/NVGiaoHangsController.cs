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
    public class NVGiaoHangsController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: NVGiaoHangs
        public ActionResult Index()
        {
            return View(db.NVGiaoHangs.ToList());
        }

        // GET: NVGiaoHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVGiaoHang nVGiaoHang = db.NVGiaoHangs.Find(id);
            if (nVGiaoHang == null)
            {
                return HttpNotFound();
            }
            return View(nVGiaoHang);
        }

        // GET: NVGiaoHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NVGiaoHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNVGH,TenNVGH,SoDienThoai")] NVGiaoHang nVGiaoHang)
        {
            if (ModelState.IsValid)
            {
                db.NVGiaoHangs.Add(nVGiaoHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nVGiaoHang);
        }

        // GET: NVGiaoHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVGiaoHang nVGiaoHang = db.NVGiaoHangs.Find(id);
            if (nVGiaoHang == null)
            {
                return HttpNotFound();
            }
            return View(nVGiaoHang);
        }

        // POST: NVGiaoHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNVGH,TenNVGH,SoDienThoai")] NVGiaoHang nVGiaoHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nVGiaoHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nVGiaoHang);
        }

        // GET: NVGiaoHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVGiaoHang nVGiaoHang = db.NVGiaoHangs.Find(id);
            if (nVGiaoHang == null)
            {
                return HttpNotFound();
            }
            return View(nVGiaoHang);
        }

        // POST: NVGiaoHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NVGiaoHang nVGiaoHang = db.NVGiaoHangs.Find(id);
            db.NVGiaoHangs.Remove(nVGiaoHang);
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
