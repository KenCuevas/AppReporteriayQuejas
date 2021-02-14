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
    public class tipoQuejasController : Controller
    {
        private ReporteDBEntities2 db = new ReporteDBEntities2();

        // GET: tipoQuejas
        public ActionResult Index()
        {
            return View(db.tipoQuejas.ToList());
        }

        // GET: tipoQuejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoQueja tipoQueja = db.tipoQuejas.Find(id);
            if (tipoQueja == null)
            {
                return HttpNotFound();
            }
            return View(tipoQueja);
        }

        // GET: tipoQuejas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoQuejas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipoQuejaID,nombreQueja")] tipoQueja tipoQueja)
        {
            if (ModelState.IsValid)
            {
                db.tipoQuejas.Add(tipoQueja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoQueja);
        }

        // GET: tipoQuejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoQueja tipoQueja = db.tipoQuejas.Find(id);
            if (tipoQueja == null)
            {
                return HttpNotFound();
            }
            return View(tipoQueja);
        }

        // POST: tipoQuejas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipoQuejaID,nombreQueja")] tipoQueja tipoQueja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoQueja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoQueja);
        }

        // GET: tipoQuejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoQueja tipoQueja = db.tipoQuejas.Find(id);
            if (tipoQueja == null)
            {
                return HttpNotFound();
            }
            return View(tipoQueja);
        }

        // POST: tipoQuejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoQueja tipoQueja = db.tipoQuejas.Find(id);
            db.tipoQuejas.Remove(tipoQueja);
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
