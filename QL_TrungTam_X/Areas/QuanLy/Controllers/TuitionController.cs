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
    public class TuitionController : BaseController
    {
        private QLTrungTamEntities db = new QLTrungTamEntities();

        // GET: /QuanLy/Tuition/
        public ActionResult Index()
        {
            var tuitions = db.Tuitions.Include(t => t.Class).Include(t => t.Student);
            return View(tuitions.ToList());
        }

        // GET: /QuanLy/Tuition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuition tuition = db.Tuitions.Find(id);
            if (tuition == null)
            {
                return HttpNotFound();
            }
            return View(tuition);
        }

        // GET: /QuanLy/Tuition/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName");
            return View();
        }

        // POST: /QuanLy/Tuition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TuitionID,ClassID,StudentID,ObjectsReduced,Money,Payments,Status")] Tuition tuition)
        {
            if (ModelState.IsValid)
            {
                db.Tuitions.Add(tuition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", tuition.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", tuition.StudentID);
            return View(tuition);
        }

        // GET: /QuanLy/Tuition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuition tuition = db.Tuitions.Find(id);
            if (tuition == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", tuition.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", tuition.StudentID);
            return View(tuition);
        }

        // POST: /QuanLy/Tuition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TuitionID,ClassID,StudentID,ObjectsReduced,Money,Payments,Status")] Tuition tuition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", tuition.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", tuition.StudentID);
            return View(tuition);
        }

        // GET: /QuanLy/Tuition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuition tuition = db.Tuitions.Find(id);
            if (tuition == null)
            {
                return HttpNotFound();
            }
            return View(tuition);
        }

        // POST: /QuanLy/Tuition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tuition tuition = db.Tuitions.Find(id);
            db.Tuitions.Remove(tuition);
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
