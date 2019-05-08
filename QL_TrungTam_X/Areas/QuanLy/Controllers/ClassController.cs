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
    public class ClassController : BaseController
    {
        private QLTrungTamEntities db = new QLTrungTamEntities();

        // GET: /QuanLy/Class/
        public ActionResult Index()
        {
            var classes = db.Classes.Include(s => s.Coure).Include(s => s.Teacher);
            return View(classes.ToList());

        }

        // GET: /QuanLy/Class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: /QuanLy/Class/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Coures, "CouresID", "CouresName");
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName");
            return View();
        }

        // POST: /QuanLy/Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ClassID,ClassName,CourseID,TeacherID,Tuition,SessionNum")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Coures, "CouresID", "CouresName", @class.CourseID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", @class.TeacherID);
            return View(@class);
        }

        // GET: /QuanLy/Class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Coures, "CouresID", "CouresName", @class.CourseID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", @class.TeacherID);
            return View(@class);
        }

        // POST: /QuanLy/Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ClassID,ClassName,CourseID,TeacherID,Tuition,SessionNum")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Coures, "CouresID", "CouresName", @class.CourseID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", @class.TeacherID);
            return View(@class);
        }

        // GET: /QuanLy/Class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: /QuanLy/Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
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
