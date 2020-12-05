using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MAFRANFER.Models;

namespace MAFRANFER
{
    public class cursosController : ApiController
    {
        private cursos_onlineEntities db = new cursos_onlineEntities();

        // GET: api/cursos
        public IQueryable<curso> Getcurso()
        {
            return db.curso;
        }

        // GET: api/cursos/5
        [ResponseType(typeof(curso))]
        public IHttpActionResult Getcurso(int id)
        {
            curso curso = db.curso.Find(id);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // PUT: api/cursos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcurso(int id, curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curso.curso_id)
            {
                return BadRequest();
            }

            db.Entry(curso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/cursos
        [ResponseType(typeof(curso))]
        public IHttpActionResult Postcurso(curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.curso.Add(curso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = curso.curso_id }, curso);
        }

        // DELETE: api/cursos/5
        [ResponseType(typeof(curso))]
        public IHttpActionResult Deletecurso(int id)
        {
            curso curso = db.curso.Find(id);
            if (curso == null)
            {
                return NotFound();
            }

            db.curso.Remove(curso);
            db.SaveChanges();

            return Ok(curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cursoExists(int id)
        {
            return db.curso.Count(e => e.curso_id == id) > 0;
        }
    }
}