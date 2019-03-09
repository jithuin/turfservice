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
    public class TurfBookingFacilityListsController : ApiController
    {
        private TurfModelContainer1 db = new TurfModelContainer1();

        // GET: api/TurfBookingFacilityLists
        public IQueryable<TurfBookingFacilityList> GetTurfBookingFacilityLists()
        {
            return db.TurfBookingFacilityLists;
        }

        // GET: api/TurfBookingFacilityLists/5
        [ResponseType(typeof(TurfBookingFacilityList))]
        public async Task<IHttpActionResult> GetTurfBookingFacilityList(int id)
        {
            TurfBookingFacilityList turfBookingFacilityList = await db.TurfBookingFacilityLists.FindAsync(id);
            if (turfBookingFacilityList == null)
            {
                return NotFound();
            }

            return Ok(turfBookingFacilityList);
        }

        // PUT: api/TurfBookingFacilityLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTurfBookingFacilityList(int id, TurfBookingFacilityList turfBookingFacilityList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turfBookingFacilityList.Id)
            {
                return BadRequest();
            }

            db.Entry(turfBookingFacilityList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurfBookingFacilityListExists(id))
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

        // POST: api/TurfBookingFacilityLists
        [ResponseType(typeof(TurfBookingFacilityList))]
        public async Task<IHttpActionResult> PostTurfBookingFacilityList(TurfBookingFacilityList turfBookingFacilityList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TurfBookingFacilityLists.Add(turfBookingFacilityList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = turfBookingFacilityList.Id }, turfBookingFacilityList);
        }

        // DELETE: api/TurfBookingFacilityLists/5
        [ResponseType(typeof(TurfBookingFacilityList))]
        public async Task<IHttpActionResult> DeleteTurfBookingFacilityList(int id)
        {
            TurfBookingFacilityList turfBookingFacilityList = await db.TurfBookingFacilityLists.FindAsync(id);
            if (turfBookingFacilityList == null)
            {
                return NotFound();
            }

            db.TurfBookingFacilityLists.Remove(turfBookingFacilityList);
            await db.SaveChangesAsync();

            return Ok(turfBookingFacilityList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurfBookingFacilityListExists(int id)
        {
            return db.TurfBookingFacilityLists.Count(e => e.Id == id) > 0;
        }
    }
}