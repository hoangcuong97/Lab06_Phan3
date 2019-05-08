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
    public class ClassroomController : BaseController
    {
        private QLTrungTamEntities db = new QLTrungTamEntities();

        // GET: /QuanLy/Classroom/
        public ActionResult Index()
        {
            return View(db.Classrooms.ToList());
        }

        // GET: /QuanLy/Classroom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = db.Classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // GET: /QuanLy/Classroom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /QuanLy/Classroom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ClassroomID,ClassroomName,Size,CSVC")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                db.Classrooms.Add(classroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classroom);
        }

        // GET: /QuanLy/Classroom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = db.Classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // POST: /QuanLy/Classroom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ClassroomID,ClassroomName,Size,CSVC")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classroom);
        }

        // GET: /QuanLy/Classroom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = db.Classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // POST: /QuanLy/Classroom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classroom classroom = db.Classrooms.Find(id);
            db.Classrooms.Remove(classroom);
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
