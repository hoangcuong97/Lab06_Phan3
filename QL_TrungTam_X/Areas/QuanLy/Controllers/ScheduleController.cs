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
    public class ScheduleController : BaseController
    {
        private QLTrungTamEntities db = new QLTrungTamEntities();

        // GET: /QuanLy/Schedule/
        public ActionResult Index()
        {
            var schedules = db.Schedules.Include(s => s.Class).Include(s => s.Classroom);
            return View(schedules.ToList());
        }

        // GET: /QuanLy/Schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: /QuanLy/Schedule/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "ClassroomName");
            return View();
        }

        // POST: /QuanLy/Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ScheduleID,ClassID,ClassroomID,Shifts")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", schedule.ClassID);
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "ClassroomName", schedule.ClassroomID);
            return View(schedule);
        }

        // GET: /QuanLy/Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", schedule.ClassID);
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "ClassroomName", schedule.ClassroomID);
            return View(schedule);
        }

        // POST: /QuanLy/Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ScheduleID,ClassID,ClassroomID,Shifts")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", schedule.ClassID);
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "ClassroomName", schedule.ClassroomID);
            return View(schedule);
        }

        // GET: /QuanLy/Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: /QuanLy/Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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
