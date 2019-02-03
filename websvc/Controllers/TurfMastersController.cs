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
using websvc.Models;

namespace websvc.Controllers
{
    public class TurfMastersController : ApiController
    {
        private TurfModelContainer1 db = new TurfModelContainer1();

        // GET: api/TurfMasters
        public IQueryable<TurfMaster> GetTurfMasters()
        {
            return db.TurfMasters;
        }

        // GET: api/TurfMasters/5
        [ResponseType(typeof(TurfMaster))]
        public async Task<IHttpActionResult> GetTurfMaster(int id)
        {
            TurfMaster turfMaster = await db.TurfMasters.FindAsync(id);
            if (turfMaster == null)
            {
                return NotFound();
            }

            return Ok(turfMaster);
        }

        // PUT: api/TurfMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTurfMaster(int id, TurfMaster turfMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turfMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(turfMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurfMasterExists(id))
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

        // POST: api/TurfMasters
        [ResponseType(typeof(TurfMaster))]
        public async Task<IHttpActionResult> PostTurfMaster(TurfMaster turfMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TurfMasters.Add(turfMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = turfMaster.Id }, turfMaster);
        }

        // DELETE: api/TurfMasters/5
        [ResponseType(typeof(TurfMaster))]
        public async Task<IHttpActionResult> DeleteTurfMaster(int id)
        {
            TurfMaster turfMaster = await db.TurfMasters.FindAsync(id);
            if (turfMaster == null)
            {
                return NotFound();
            }

            db.TurfMasters.Remove(turfMaster);
            await db.SaveChangesAsync();

            return Ok(turfMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurfMasterExists(int id)
        {
            return db.TurfMasters.Count(e => e.Id == id) > 0;
        }
    }
}