using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CustomerAPI.Models;

namespace CustomerAPI.Controllers
{
    [Authorize]
    public class RepresentativesController : ApiController
    {
        private CustomerAPIContext db = new CustomerAPIContext();

        // GET: api/Representatives
        public IQueryable<Representatives> GetRepresentatives()
        {
            return db.Representatives;
        }

        // GET: api/Representatives/5
        [ResponseType(typeof(Representatives))]
        public async Task<IHttpActionResult> GetRepresentatives(int id)
        {
            Representatives representatives = await db.Representatives.FindAsync(id);
            if (representatives == null)
            {
                return NotFound();
            }

            return Ok(representatives);
        }

        // PUT: api/Representatives/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRepresentatives(int id, Representatives representatives)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != representatives.Id)
            {
                return BadRequest();
            }

            db.Entry(representatives).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepresentativesExists(id))
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

        // POST: api/Representatives
        [ResponseType(typeof(Representatives))]
        public async Task<IHttpActionResult> PostRepresentatives(Representatives representatives)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Representatives.Add(representatives);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = representatives.Id }, representatives);
        }

        // DELETE: api/Representatives/5
        [ResponseType(typeof(Representatives))]
        public async Task<IHttpActionResult> DeleteRepresentatives(int id)
        {
            Representatives representatives = await db.Representatives.FindAsync(id);
            if (representatives == null)
            {
                return NotFound();
            }

            db.Representatives.Remove(representatives);
            await db.SaveChangesAsync();

            return Ok(representatives);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepresentativesExists(int id)
        {
            return db.Representatives.Count(e => e.Id == id) > 0;
        }
    }
}