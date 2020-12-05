using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MAFRANFER.Models;

namespace MAFRANFER.Controllers
{
    [Authorize]
    public class inscripcionesController : Controller
    {
        private cursos_onlineEntities db = new cursos_onlineEntities();

        // GET: inscripciones
        public ActionResult Index()
        {
            var inscripcion = db.inscripcion.Include(i => i.curso).Include(i => i.estudiante);
            return View(inscripcion.ToList());
        }

        // GET: inscripciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inscripcion inscripcion = db.inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // GET: inscripciones/Create
        public ActionResult Create()
        {
            ViewBag.curso_id = new SelectList(db.curso, "curso_id", "descripcion");
            ViewBag.estudiante_id = new SelectList(db.estudiante, "estudiante_id", "nro_documento");
            return View();
        }

        // POST: inscripciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "inscripcion_id,estudiante_id,fecha,importe,estado,observacion,curso_id")] inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.inscripcion.Add(inscripcion);
                inscripcion.fecha = DateTime.Now;
                inscripcion.estado = "A";

                decimal precio = (from c in db.curso
                                         where c.curso_id == inscripcion.curso_id
                                         select (decimal)c.precio).FirstOrDefault();
                inscripcion.importe = precio;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.curso_id = new SelectList(db.curso, "curso_id", "descripcion", inscripcion.curso_id);
            ViewBag.estudiante_id = new SelectList(db.estudiante, "estudiante_id", "nro_documento", inscripcion.estudiante_id);
            return View(inscripcion);
        }

        // GET: inscripciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inscripcion inscripcion = db.inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.curso_id = new SelectList(db.curso, "curso_id", "descripcion", inscripcion.curso_id);
            ViewBag.estudiante_id = new SelectList(db.estudiante, "estudiante_id", "nro_documento", inscripcion.estudiante_id);
            return View(inscripcion);
        }

        // POST: inscripciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "inscripcion_id,estudiante_id,fecha,importe,estado,observacion,curso_id")] inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.curso_id = new SelectList(db.curso, "curso_id", "descripcion", inscripcion.curso_id);
            ViewBag.estudiante_id = new SelectList(db.estudiante, "estudiante_id", "nro_documento", inscripcion.estudiante_id);
            return View(inscripcion);
        }

        // GET: inscripciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inscripcion inscripcion = db.inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // POST: inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inscripcion inscripcion = db.inscripcion.Find(id);
            db.inscripcion.Remove(inscripcion);
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
