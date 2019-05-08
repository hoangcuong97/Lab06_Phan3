using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QL_TrungTam_X.Areas.QuanLy.Models;

namespace QL_TrungTam_X.Areas.QuanLy.Controllers
{
    public class CoureController : BaseController
    {
        private QLTrungTamEntities db = new QLTrungTamEntities();

        // GET: /QuanLy/Coure/
        public ActionResult Index()
        {
            return View(db.Coures.ToList());
        }

        // GET: /QuanLy/Coure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coure coure = db.Coures.Find(id);
            if (coure == null)
            {
                return HttpNotFound();
            }
            return View(coure);
        }

        // GET: /QuanLy/Coure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /QuanLy/Coure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CouresID,CouresName,Conditions,Object,Contents,Target")] Coure coure)
        {
            if (ModelState.IsValid)
            {
                db.Coures.Add(coure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coure);
        }

        // GET: /QuanLy/Coure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coure coure = db.Coures.Find(id);
            if (coure == null)
            {
                return HttpNotFound();
            }
            return View(coure);
        }

        // POST: /QuanLy/Coure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CouresID,CouresName,Conditions,Object,Contents,Target")] Coure coure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coure);
        }

        // GET: /QuanLy/Coure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coure coure = db.Coures.Find(id);
            if (coure == null)
            {
                return HttpNotFound();
            }
            return View(coure);
        }

        // POST: /QuanLy/Coure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coure coure = db.Coures.Find(id);
            db.Coures.Remove(coure);
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
