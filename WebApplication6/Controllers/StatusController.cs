using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6;

namespace WebApplication6.Controllers
{
    public class StatusController : Controller
    {
        private ReporteDBEntities2 db = new ReporteDBEntities2();

        // GET: Status
        public ActionResult Index()
        {
            var status = db.Status.Include(s => s.Departamento).Include(s => s.tipoStatu);
            return View(status.ToList());
        }

        // GET: Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // GET: Status/Create
        public ActionResult Create()
        {
            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep");
            ViewBag.IdTipoStatus = new SelectList(db.tipoStatus, "IdTipoStatus", "nombreStatus");
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "statusID,descripcionStatus,fechaContacto,depID,comentarios,empID,IdTipoStatus")] Status status)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep", status.depID);
            ViewBag.IdTipoStatus = new SelectList(db.tipoStatus, "IdTipoStatus", "nombreStatus", status.IdTipoStatus);
            return View(status);
        }

        // GET: Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep", status.depID);
            ViewBag.IdTipoStatus = new SelectList(db.tipoStatus, "IdTipoStatus", "nombreStatus", status.IdTipoStatus);
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "statusID,descripcionStatus,fechaContacto,depID,comentarios,empID,IdTipoStatus")] Status status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep", status.depID);
            ViewBag.IdTipoStatus = new SelectList(db.tipoStatus, "IdTipoStatus", "nombreStatus", status.IdTipoStatus);
            return View(status);
        }

        // GET: Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status status = db.Status.Find(id);
            db.Status.Remove(status);
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
