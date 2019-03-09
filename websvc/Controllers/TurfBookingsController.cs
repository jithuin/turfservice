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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using websvc.Models;

namespace websvc.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class TurfBookingsController : ApiController
    {
        private TurfModelContainer1 db = new TurfModelContainer1();

        // GET: api/TurfBookings
        public IQueryable<TurfBooking> GetTurfBookings()
        {
            return db.TurfBookings;
        }

        // GET: api/TurfBookings/5
        [ResponseType(typeof(TurfBooking))]
        public async Task<IHttpActionResult> GetTurfBooking(int id)
        {
            TurfBooking turfBooking = await db.TurfBookings.FindAsync(id);
            if (turfBooking == null)
            {
                return NotFound();
            }

            return Ok(turfBooking);
        }

        // PUT: api/TurfBookings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTurfBooking(int id, TurfBooking turfBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turfBooking.Id)
            {
                return BadRequest();
            }

            db.Entry(turfBooking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurfBookingExists(id))
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

        // POST: api/TurfBookings
        [ResponseType(typeof(TurfBooking))]
        public async Task<IHttpActionResult> PostTurfBooking(TurfBooking turfBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TurfBookings.Add(turfBooking);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = turfBooking.Id }, turfBooking);
        }

        // DELETE: api/TurfBookings/5
        [ResponseType(typeof(TurfBooking))]
        public async Task<IHttpActionResult> DeleteTurfBooking(int id)
        {
            TurfBooking turfBooking = await db.TurfBookings.FindAsync(id);
            if (turfBooking == null)
            {
                return NotFound();
            }

            db.TurfBookings.Remove(turfBooking);
            await db.SaveChangesAsync();

            return Ok(turfBooking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurfBookingExists(int id)
        {
            return db.TurfBookings.Count(e => e.Id == id) > 0;
        }
    }
}