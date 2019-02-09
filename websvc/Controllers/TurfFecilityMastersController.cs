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
    public class TurfFecilityMastersController : ApiController
    {
        private TurfModelContainer1 db = new TurfModelContainer1();

        // GET: api/TurfFecilityMasters
        public IQueryable<TurfFecilityMaster> GetTurfFecilityMasters()
        {
            return db.TurfFecilityMasters;
        }

        // GET: api/TurfFecilityMasters/5
        [ResponseType(typeof(TurfFecilityMaster))]
        public async Task<IHttpActionResult> GetTurfFecilityMaster(int id)
        {
            TurfFecilityMaster turfFecilityMaster = await db.TurfFecilityMasters.FindAsync(id);
            if (turfFecilityMaster == null)
            {
                return NotFound();
            }

            return Ok(turfFecilityMaster);
        }

        // PUT: api/TurfFecilityMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTurfFecilityMaster(int id, TurfFecilityMaster turfFecilityMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turfFecilityMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(turfFecilityMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurfFecilityMasterExists(id))
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

        // POST: api/TurfFecilityMasters
        [ResponseType(typeof(TurfFecilityMaster))]
        public async Task<IHttpActionResult> PostTurfFecilityMaster(TurfFecilityMaster turfFecilityMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TurfFecilityMasters.Add(turfFecilityMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = turfFecilityMaster.Id }, turfFecilityMaster);
        }

        // DELETE: api/TurfFecilityMasters/5
        [ResponseType(typeof(TurfFecilityMaster))]
        public async Task<IHttpActionResult> DeleteTurfFecilityMaster(int id)
        {
            TurfFecilityMaster turfFecilityMaster = await db.TurfFecilityMasters.FindAsync(id);
            if (turfFecilityMaster == null)
            {
                return NotFound();
            }

            db.TurfFecilityMasters.Remove(turfFecilityMaster);
            await db.SaveChangesAsync();

            return Ok(turfFecilityMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurfFecilityMasterExists(int id)
        {
            return db.TurfFecilityMasters.Count(e => e.Id == id) > 0;
        }
    }
}