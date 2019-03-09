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
    public class TurfGroupsController : ApiController
    {
        private TurfModelContainer1 db = new TurfModelContainer1();

        // GET: api/TurfGroups
        public IQueryable<TurfGroup> GetTurfGroups()
        {
            return db.TurfGroups;
        }

        // GET: api/TurfGroups/5
        [ResponseType(typeof(TurfGroup))]
        public async Task<IHttpActionResult> GetTurfGroup(int id)
        {
            TurfGroup turfGroup = await db.TurfGroups.FindAsync(id);
            if (turfGroup == null)
            {
                return NotFound();
            }

            return Ok(turfGroup);
        }

        // PUT: api/TurfGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTurfGroup(int id, TurfGroup turfGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turfGroup.Id)
            {
                return BadRequest();
            }

            db.Entry(turfGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurfGroupExists(id))
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

        // POST: api/TurfGroups
        [ResponseType(typeof(TurfGroup))]
        public async Task<IHttpActionResult> PostTurfGroup(TurfGroup turfGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TurfGroups.Add(turfGroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = turfGroup.Id }, turfGroup);
        }

        // DELETE: api/TurfGroups/5
        [ResponseType(typeof(TurfGroup))]
        public async Task<IHttpActionResult> DeleteTurfGroup(int id)
        {
            TurfGroup turfGroup = await db.TurfGroups.FindAsync(id);
            if (turfGroup == null)
            {
                return NotFound();
            }

            db.TurfGroups.Remove(turfGroup);
            await db.SaveChangesAsync();

            return Ok(turfGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurfGroupExists(int id)
        {
            return db.TurfGroups.Count(e => e.Id == id) > 0;
        }
    }
}