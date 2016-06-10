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
using il_Topolino.Models;

namespace il_Topolino.Controllers
{
    public class GerechtensController : ApiController
    {
        private TopolinoEntities3 db = new TopolinoEntities3();

        // GET: api/Gerechtens
        public IQueryable GetGerechten()
        {
            var qry = (from gerecht in db.Gerechten
                       join categorie in db.Gerecht_categorie on gerecht.categorie_id equals categorie.categorie_id
                       select new { Categorie = categorie.categorie_naam, Gerecht = gerecht.gerecht_naam, MenuID = gerecht.gerecht_id });
            return qry;
            //return db.Gerechten;
        }

        // GET: api/Gerechtens/5
        [ResponseType(typeof(Gerechten))]
        public IHttpActionResult GetGerechten(int id)
        {
            Gerechten gerechten = db.Gerechten.Find(id);
            if (gerechten == null)
            {
                return NotFound();
            }

            return Ok(gerechten);
        }

        // PUT: api/Gerechtens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGerechten(int id, Gerechten gerechten)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gerechten.gerecht_id)
            {
                return BadRequest();
            }

            db.Entry(gerechten).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GerechtenExists(id))
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

        // POST: api/Gerechtens
        [ResponseType(typeof(Gerechten))]
        public IHttpActionResult PostGerechten(Gerechten gerechten)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gerechten.Add(gerechten);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gerechten.gerecht_id }, gerechten);
        }

        // DELETE: api/Gerechtens/5
        [ResponseType(typeof(Gerechten))]
        public IHttpActionResult DeleteGerechten(int id)
        {
            Gerechten gerechten = db.Gerechten.Find(id);
            if (gerechten == null)
            {
                return NotFound();
            }

            db.Gerechten.Remove(gerechten);
            db.SaveChanges();

            return Ok(gerechten);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GerechtenExists(int id)
        {
            return db.Gerechten.Count(e => e.gerecht_id == id) > 0;
        }
    }
}