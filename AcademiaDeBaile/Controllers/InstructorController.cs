using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcademiaDeBaile;
using Newtonsoft.Json;

namespace AcademiaDeBaile.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        private AcademiaDeBaileEntities db = new AcademiaDeBaileEntities();

        // GET: Instructor
        public ActionResult Index()
        {
            //Experion landa

            /*Donde un instructor tenga mas de un año de esperiencia
            var query = db.Instructor.Where(inst => inst.AñosExperiencia > 1);*/

            /*Fecha de nacimiento menor al 1995.
            /var fecha = new DateTime(1994, 12, 31);
            /var query = db.Instructor.Where(inst => inst.FechaNacimiento <= fecha);*/


            /*Una cedula que contenga un uno
            var query = db.Instructor.Where(inst => inst.Cedula.Contains("1"));*/

            /*Esta sentencia dice qes igual a un select * from instructor
            var query = (from inst in db.Instructor select inst); */

            /*var fecha = new DateTime(1994, 01, 01);
            var query = (from inst in db.Instructor
                         where inst.Apellidos.ToLower().Contains("z") && inst.FechaNacimiento >= fecha
                         select inst);  */

            /*var fecha = DateTime.Now.AddYears(-18);
            var query = (from inst in db.Instructor
                         where inst.Apellidos.ToLower().Contains("z") && inst.FechaNacimiento <= fecha
                         select inst);*/

            //var query = (from inst in db.Instructor
            //             join cla in db.Clase on inst.Id equals cla.IdInstructor
            //             select inst).Distinct();


            return View(db.Instructor.ToList());
            //return View(query.ToList());
        }

        //public string Detalles(long id)
        //{
        //    var registro = db.Instructor.Find(id);

        //    return JsonConvert.SerializeObject(registro, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    }); 
        //}

        // GET: Instructor/Details/5

        public string Detalles(long id)
        {
            var registro = db.Instructor.Find(id);

            return JsonConvert.SerializeObject(registro, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        //public ActionResult Detalles(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Instructor instructor = db.Instructor.Find(id);
        //    if (instructor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(instructor);
        //}

        // GET: Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cedula,Nombre,Apellidos,Dirección,FechaNacimiento,AñosExperiencia,ExpertoEn")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructor.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructor.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cedula,Nombre,Apellidos,Dirección,FechaNacimiento,AñosExperiencia,ExpertoEn")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructor.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Instructor instructor = db.Instructor.Find(id);
            db.Instructor.Remove(instructor);
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
