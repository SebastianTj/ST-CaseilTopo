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
    public class IngredientensController : ApiController
    {
        private TopolinoEntities3 db = new TopolinoEntities3();

        // GET: api/Ingredientens
        public IQueryable<Ingredienten> GetIngredienten()
        {
            return (from ing in db.Ingredienten
                    where ing.isTopping
                    select ing);
            //return db.Ingredienten;
        }

        // GET: api/Ingredientens/5
        [ResponseType(typeof(Ingredienten))]
        public IHttpActionResult GetIngredienten(int id)
        {
            Ingredienten ingredienten = db.Ingredienten.Find(id);
            if (ingredienten == null)
            {
                return NotFound();
            }

            return Ok(ingredienten);
        }

        // PUT: api/Ingredientens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngredienten(int id, Ingredienten ingredienten)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredienten.ingredient_id)
            {
                return BadRequest();
            }

            db.Entry(ingredienten).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientenExists(id))
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

        // POST: api/Ingredientens
        [ResponseType(typeof(Ingredienten))]
        public IHttpActionResult PostIngredienten(Ingredienten ingredienten)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingredienten.Add(ingredienten);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingredienten.ingredient_id }, ingredienten);
        }

        // DELETE: api/Ingredientens/5
        [ResponseType(typeof(Ingredienten))]
        public IHttpActionResult DeleteIngredienten(int id)
        {
            Ingredienten ingredienten = db.Ingredienten.Find(id);
            if (ingredienten == null)
            {
                return NotFound();
            }

            db.Ingredienten.Remove(ingredienten);
            db.SaveChanges();

            return Ok(ingredienten);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientenExists(int id)
        {
            return db.Ingredienten.Count(e => e.ingredient_id == id) > 0;
        }


    }
}