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
    public class CafeteriasController : Controller
    {
        private ReporteDBEntities2 db = new ReporteDBEntities2();

        // GET: Cafeterias
        public ActionResult Index()
        {
            var cafeterias = db.Cafeterias.Include(c => c.Local).Include(c => c.TipoProducto);
            return View(cafeterias.ToList());
        }

        // GET: Cafeterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafeteria cafeteria = db.Cafeterias.Find(id);
            if (cafeteria == null)
            {
                return HttpNotFound();
            }
            return View(cafeteria);
        }

        // GET: Cafeterias/Create
        public ActionResult Create()
        {
            ViewBag.localID = new SelectList(db.Locals, "localID", "localNombre");
            ViewBag.localID = new SelectList(db.TipoProductoes, "productoID", "nombreProducto");
            return View();
        }

        // POST: Cafeterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cafID,nombreCaf,descripcionCaf,localID,productoID")] Cafeteria cafeteria)
        {
            if (ModelState.IsValid)
            {
                db.Cafeterias.Add(cafeteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.localID = new SelectList(db.Locals, "localID", "localNombre", cafeteria.localID);
            ViewBag.localID = new SelectList(db.TipoProductoes, "productoID", "nombreProducto", cafeteria.localID);
            return View(cafeteria);
        }

        // GET: Cafeterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafeteria cafeteria = db.Cafeterias.Find(id);
            if (cafeteria == null)
            {
                return HttpNotFound();
            }
            ViewBag.localID = new SelectList(db.Locals, "localID", "localNombre", cafeteria.localID);
            ViewBag.localID = new SelectList(db.TipoProductoes, "productoID", "nombreProducto", cafeteria.localID);
            return View(cafeteria);
        }

        // POST: Cafeterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cafID,nombreCaf,descripcionCaf,localID,productoID")] Cafeteria cafeteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cafeteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.localID = new SelectList(db.Locals, "localID", "localNombre", cafeteria.localID);
            ViewBag.localID = new SelectList(db.TipoProductoes, "productoID", "nombreProducto", cafeteria.localID);
            return View(cafeteria);
        }

        // GET: Cafeterias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafeteria cafeteria = db.Cafeterias.Find(id);
            if (cafeteria == null)
            {
                return HttpNotFound();
            }
            return View(cafeteria);
        }

        // POST: Cafeterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cafeteria cafeteria = db.Cafeterias.Find(id);
            db.Cafeterias.Remove(cafeteria);
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
