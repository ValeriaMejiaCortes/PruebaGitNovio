using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcademiaDeBaile;

namespace AcademiaDeBaile.Controllers
{
    [Authorize]
    public class ClaseController : Controller
    {
        private AcademiaDeBaileEntities db = new AcademiaDeBaileEntities();

        // GET: Clase
        public ActionResult Index()
        {
            var clase = db.Clase.Include(c => c.Instructor);
            return View(clase.ToList());
        }

        // GET: Clase/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clase clase = db.Clase.Find(id);
            if (clase == null)
            {
                return HttpNotFound();
            }
            return View(clase);
        }

        // GET: Clase/Create
        public ActionResult Create()
        {
            ViewBag.IdInstructor = new SelectList(db.Instructor, "Id", "Cedula");
            return View();
        }

        // POST: Clase/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Horario,Duración,IdInstructor")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                db.Clase.Add(clase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdInstructor = new SelectList(db.Instructor, "Id", "Cedula", clase.IdInstructor);
            return View(clase);
        }

        // GET: Clase/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clase clase = db.Clase.Find(id);
            if (clase == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdInstructor = new SelectList(db.Instructor, "Id", "Cedula", clase.IdInstructor);
            return View(clase);
        }

        // POST: Clase/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Horario,Duración,IdInstructor")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdInstructor = new SelectList(db.Instructor, "Id", "Cedula", clase.IdInstructor);
            return View(clase);
        }

        // GET: Clase/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clase clase = db.Clase.Find(id);
            if (clase == null)
            {
                return HttpNotFound();
            }
            return View(clase);
        }

        // POST: Clase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Clase clase = db.Clase.Find(id);
            db.Clase.Remove(clase);
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
