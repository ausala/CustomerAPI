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
    //[Authorize]
    public class CustomersController : ApiController
    {
        private CustomerAPIContext db = new CustomerAPIContext();

        // GET: api/Customers
        public IQueryable<Customers> GetCustomers()
        {
            return db.Customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customers))]
        public async Task<IHttpActionResult> GetCustomers(int id)
        {
            Customers customers = await db.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomers(int id, Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customers.Id)
            {
                return BadRequest();
            }

            db.Entry(customers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customers))]
        public async Task<IHttpActionResult> PostCustomers(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customers.Id }, customers);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customers))]
        public async Task<IHttpActionResult> DeleteCustomers(int id)
        {
            Customers customers = await db.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customers);
            await db.SaveChangesAsync();

            return Ok(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomersExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}