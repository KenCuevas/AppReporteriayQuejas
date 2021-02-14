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
    public class tipoStatusController : Controller
    {
        private ReporteDBEntities2 db = new ReporteDBEntities2();

        // GET: tipoStatus
        public ActionResult Index()
        {
            return View(db.tipoStatus.ToList());
        }

        // GET: tipoStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoStatu tipoStatu = db.tipoStatus.Find(id);
            if (tipoStatu == null)
            {
                return HttpNotFound();
            }
            return View(tipoStatu);
        }

        // GET: tipoStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoStatus,nombreStatus")] tipoStatu tipoStatu)
        {
            if (ModelState.IsValid)
            {
                db.tipoStatus.Add(tipoStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoStatu);
        }

        // GET: tipoStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoStatu tipoStatu = db.tipoStatus.Find(id);
            if (tipoStatu == null)
            {
                return HttpNotFound();
            }
            return View(tipoStatu);
        }

        // POST: tipoStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoStatus,nombreStatus")] tipoStatu tipoStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoStatu);
        }

        // GET: tipoStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoStatu tipoStatu = db.tipoStatus.Find(id);
            if (tipoStatu == null)
            {
                return HttpNotFound();
            }
            return View(tipoStatu);
        }

        // POST: tipoStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoStatu tipoStatu = db.tipoStatus.Find(id);
            db.tipoStatus.Remove(tipoStatu);
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
