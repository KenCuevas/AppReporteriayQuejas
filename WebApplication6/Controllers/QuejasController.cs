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
    public class QuejasController : Controller
    {
        private ReporteDBEntities2 db = new ReporteDBEntities2();

        // GET: Quejas
        public ActionResult Index()
        {
            var quejas = db.Quejas.Include(q => q.Departamento).Include(q => q.Status).Include(q => q.tipoQueja);
            return View(quejas.ToList());
        }

        // GET: Quejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queja queja = db.Quejas.Find(id);
            if (queja == null)
            {
                return HttpNotFound();
            }
            return View(queja);
        }

        // GET: Quejas/Create
        public ActionResult Create()
        {
            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep");
            ViewBag.statusID = new SelectList(db.Status, "statusID", "descripcionStatus");
            ViewBag.tipoQuejaID = new SelectList(db.tipoQuejas, "tipoQuejaID", "nombreQueja");
            return View();
        }

        // POST: Quejas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuejaID,nombre,apellido,depID,fecha,hora,tipoQuejaID,statusID")] Queja queja)
        {
            if (ModelState.IsValid)
            {
                db.Quejas.Add(queja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep", queja.depID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "descripcionStatus", queja.statusID);
            ViewBag.tipoQuejaID = new SelectList(db.tipoQuejas, "tipoQuejaID", "nombreQueja", queja.tipoQuejaID);
            return View(queja);
        }

        // GET: Quejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queja queja = db.Quejas.Find(id);
            if (queja == null)
            {
                return HttpNotFound();
            }
            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep", queja.depID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "descripcionStatus", queja.statusID);
            ViewBag.tipoQuejaID = new SelectList(db.tipoQuejas, "tipoQuejaID", "nombreQueja", queja.tipoQuejaID);
            return View(queja);
        }

        // POST: Quejas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuejaID,nombre,apellido,depID,fecha,hora,tipoQuejaID,statusID")] Queja queja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depID = new SelectList(db.Departamentoes, "depID", "nombreDep", queja.depID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "descripcionStatus", queja.statusID);
            ViewBag.tipoQuejaID = new SelectList(db.tipoQuejas, "tipoQuejaID", "nombreQueja", queja.tipoQuejaID);
            return View(queja);
        }

        // GET: Quejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queja queja = db.Quejas.Find(id);
            if (queja == null)
            {
                return HttpNotFound();
            }
            return View(queja);
        }

        // POST: Quejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Queja queja = db.Quejas.Find(id);
            db.Quejas.Remove(queja);
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
