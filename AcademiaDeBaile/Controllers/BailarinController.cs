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
    public class BailarinController : Controller
    {
        private AcademiaDeBaileEntities db = new AcademiaDeBaileEntities();

        // GET: Bailarin
        public ActionResult Index()
        {
            return View(db.Bailarin.ToList());
        }

        // GET: Bailarin/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bailarin bailarin = db.Bailarin.Find(id);
            if (bailarin == null)
            {
                return HttpNotFound();
            }
            return View(bailarin);
        }

        // GET: Bailarin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bailarin/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Documento,Nombre,Apellido,Edad,Sexo,Telefono,Email")] Bailarin bailarin)
        {
            if (ModelState.IsValid)
            {
                db.Bailarin.Add(bailarin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bailarin);
        }

        // GET: Bailarin/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bailarin bailarin = db.Bailarin.Find(id);
            if (bailarin == null)
            {
                return HttpNotFound();
            }
            return View(bailarin);
        }

        // POST: Bailarin/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Documento,Nombre,Apellido,Edad,Sexo,Telefono,Email")] Bailarin bailarin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bailarin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bailarin);
        }

        // GET: Bailarin/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bailarin bailarin = db.Bailarin.Find(id);
            if (bailarin == null)
            {
                return HttpNotFound();
            }
            return View(bailarin);
        }

        // POST: Bailarin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Bailarin bailarin = db.Bailarin.Find(id);
            db.Bailarin.Remove(bailarin);
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
