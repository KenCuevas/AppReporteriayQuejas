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
    public class ReclamoesController : Controller
    {
        private ReporteDBEntities2 db = new ReporteDBEntities2();

        // GET: Reclamoes
        public ActionResult Index()
        {
            var reclamos = db.Reclamos.Include(r => r.Departamento).Include(r => r.Status).Include(r => r.TipoDeReclamo);
            return View(reclamos.ToList());
        }

        // GET: Reclamoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamo reclamo = db.Reclamos.Find(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        // GET: Reclamoes/Create
        public ActionResult Create()
        {
            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep");
            ViewBag.statusID = new SelectList(db.Status, "statusID", "descripcionStatus");
            ViewBag.IdTipoReclamo = new SelectList(db.TipoDeReclamoes, "IdTipoReclamo", "tipoReclamo");
            return View();
        }

        // POST: Reclamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reclamoID,nombre,apellido,depID,fechaReclamo,horaReclamo,IdTipoReclamo,statusID")] Reclamo reclamo)
        {
            if (ModelState.IsValid)
            {
                db.Reclamos.Add(reclamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep", reclamo.depID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "descripcionStatus", reclamo.statusID);
            ViewBag.IdTipoReclamo = new SelectList(db.TipoDeReclamoes, "IdTipoReclamo", "tipoReclamo", reclamo.IdTipoReclamo);
            return View(reclamo);
        }

        // GET: Reclamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamo reclamo = db.Reclamos.Find(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep", reclamo.depID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "descripcionStatus", reclamo.statusID);
            ViewBag.IdTipoReclamo = new SelectList(db.TipoDeReclamoes, "IdTipoReclamo", "tipoReclamo", reclamo.IdTipoReclamo);
            return View(reclamo);
        }

        // POST: Reclamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reclamoID,nombre,apellido,depID,fechaReclamo,horaReclamo,IdTipoReclamo,statusID")] Reclamo reclamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep", reclamo.depID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "descripcionStatus", reclamo.statusID);
            ViewBag.IdTipoReclamo = new SelectList(db.TipoDeReclamoes, "IdTipoReclamo", "tipoReclamo", reclamo.IdTipoReclamo);
            return View(reclamo);
        }

        // GET: Reclamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamo reclamo = db.Reclamos.Find(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        // POST: Reclamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclamo reclamo = db.Reclamos.Find(id);
            db.Reclamos.Remove(reclamo);
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
