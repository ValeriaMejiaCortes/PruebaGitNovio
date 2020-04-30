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
    public class ClaseBailarinController : Controller
    {
        private AcademiaDeBaileEntities db = new AcademiaDeBaileEntities();

        // GET: ClaseBailarin
        public ActionResult Index()
        {
            var claseBailarin = db.ClaseBailarin.Include(c => c.Bailarin).Include(c => c.Clase);
            return View(claseBailarin.ToList());
        }

        // GET: ClaseBailarin/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseBailarin claseBailarin = db.ClaseBailarin.Find(id);
            if (claseBailarin == null)
            {
                return HttpNotFound();
            }
            return View(claseBailarin);
        }

        // GET: ClaseBailarin/Create
        public ActionResult Create()
        {
            ViewBag.IdBailarin = new SelectList(db.Bailarin, "Id", "Nombre");
            ViewBag.idClase = new SelectList(db.Clase, "Id", "Nombre");
            return View();
        }

        // POST: ClaseBailarin/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClase,IdBailarin,Id")] ClaseBailarin claseBailarin)
        {
            if (ModelState.IsValid)
            {
                db.ClaseBailarin.Add(claseBailarin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBailarin = new SelectList(db.Bailarin, "Id", "Nombre", claseBailarin.IdBailarin);
            ViewBag.idClase = new SelectList(db.Clase, "Id", "Nombre", claseBailarin.idClase);
            return View(claseBailarin);
        }

        // GET: ClaseBailarin/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseBailarin claseBailarin = db.ClaseBailarin.Find(id);
            if (claseBailarin == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBailarin = new SelectList(db.Bailarin, "Id", "Nombre", claseBailarin.IdBailarin);
            ViewBag.idClase = new SelectList(db.Clase, "Id", "Nombre", claseBailarin.idClase);
            return View(claseBailarin);
        }

        // POST: ClaseBailarin/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClase,IdBailarin,Id")] ClaseBailarin claseBailarin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claseBailarin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBailarin = new SelectList(db.Bailarin, "Id", "Nombre", claseBailarin.IdBailarin);
            ViewBag.idClase = new SelectList(db.Clase, "Id", "Nombre", claseBailarin.idClase);
            return View(claseBailarin);
        }

        // GET: ClaseBailarin/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseBailarin claseBailarin = db.ClaseBailarin.Find(id);
            if (claseBailarin == null)
            {
                return HttpNotFound();
            }
            return View(claseBailarin);
        }

        // POST: ClaseBailarin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ClaseBailarin claseBailarin = db.ClaseBailarin.Find(id);
            db.ClaseBailarin.Remove(claseBailarin);
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
