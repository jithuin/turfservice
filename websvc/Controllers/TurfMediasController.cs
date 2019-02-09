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
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class TurfMediasController : ApiController
    {
        private TurfModelContainer1 db = new TurfModelContainer1();

        // GET: api/TurfMedias
        public IQueryable<TurfMedia> GetTurfMedias()
        {
            return db.TurfMedias;
        }

        // GET: api/TurfMedias/5
        [ResponseType(typeof(TurfMedia))]
        public async Task<IHttpActionResult> GetTurfMedia(int id)
        {
            TurfMedia turfMedia = await db.TurfMedias.FindAsync(id);
            if (turfMedia == null)
            {
                return NotFound();
            }

            return Ok(turfMedia);
        }

        // PUT: api/TurfMedias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTurfMedia(int id, TurfMedia turfMedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turfMedia.Id)
            {
                return BadRequest();
            }

            db.Entry(turfMedia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurfMediaExists(id))
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

        // POST: api/TurfMedias
        [ResponseType(typeof(TurfMedia))]
        public async Task<IHttpActionResult> PostTurfMedia(TurfMedia turfMedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TurfMedias.Add(turfMedia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = turfMedia.Id }, turfMedia);
        }

        // DELETE: api/TurfMedias/5
        [ResponseType(typeof(TurfMedia))]
        public async Task<IHttpActionResult> DeleteTurfMedia(int id)
        {
            TurfMedia turfMedia = await db.TurfMedias.FindAsync(id);
            if (turfMedia == null)
            {
                return NotFound();
            }

            db.TurfMedias.Remove(turfMedia);
            await db.SaveChangesAsync();

            return Ok(turfMedia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurfMediaExists(int id)
        {
            return db.TurfMedias.Count(e => e.Id == id) > 0;
        }
    }
}