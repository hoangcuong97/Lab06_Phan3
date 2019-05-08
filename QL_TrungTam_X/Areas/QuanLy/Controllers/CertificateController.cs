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
    public class CertificateController : BaseController
    {
        private QLTrungTamEntities db = new QLTrungTamEntities();

        // GET: /QuanLy/Certificate/
        public ActionResult Index()
        {
            var certificates = db.Certificates.Include(c => c.Coure);
            return View(certificates.ToList());
        }

        // GET: /QuanLy/Certificate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
        }

        // GET: /QuanLy/Certificate/Create
        public ActionResult Create()
        {
            ViewBag.CouresID = new SelectList(db.Coures, "CouresID", "CouresName");
            return View();
        }

        // POST: /QuanLy/Certificate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CertificateID,CertificateName,CouresID,ReleaseDate,ExpirationDate")] Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                db.Certificates.Add(certificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CouresID = new SelectList(db.Coures, "CouresID", "CouresName", certificate.CouresID);
            return View(certificate);
        }

        // GET: /QuanLy/Certificate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            ViewBag.CouresID = new SelectList(db.Coures, "CouresID", "CouresName", certificate.CouresID);
            return View(certificate);
        }

        // POST: /QuanLy/Certificate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CertificateID,CertificateName,CouresID,ReleaseDate,ExpirationDate")] Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CouresID = new SelectList(db.Coures, "CouresID", "CouresName", certificate.CouresID);
            return View(certificate);
        }

        // GET: /QuanLy/Certificate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
        }

        // POST: /QuanLy/Certificate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certificate certificate = db.Certificates.Find(id);
            db.Certificates.Remove(certificate);
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
