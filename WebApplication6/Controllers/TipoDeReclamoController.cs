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
    public class TipoDeReclamoController : Controller
    {
        private ReporteDBEntities2 db = new ReporteDBEntities2();

        // GET: TipoDeReclamo
        public ActionResult Index()
        {
            return View(db.TipoDeReclamoes.ToList());
        }

        // GET: TipoDeReclamo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeReclamo tipoDeReclamo = db.TipoDeReclamoes.Find(id);
            if (tipoDeReclamo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeReclamo);
        }

        // GET: TipoDeReclamo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeReclamo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoReclamo,tipoReclamo")] TipoDeReclamo tipoDeReclamo)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeReclamoes.Add(tipoDeReclamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeReclamo);
        }

        // GET: TipoDeReclamo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeReclamo tipoDeReclamo = db.TipoDeReclamoes.Find(id);
            if (tipoDeReclamo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeReclamo);
        }

        // POST: TipoDeReclamo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoReclamo,tipoReclamo")] TipoDeReclamo tipoDeReclamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeReclamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeReclamo);
        }

        // GET: TipoDeReclamo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeReclamo tipoDeReclamo = db.TipoDeReclamoes.Find(id);
            if (tipoDeReclamo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeReclamo);
        }

        // POST: TipoDeReclamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeReclamo tipoDeReclamo = db.TipoDeReclamoes.Find(id);
            db.TipoDeReclamoes.Remove(tipoDeReclamo);
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
