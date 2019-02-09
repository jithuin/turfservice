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
    public class TypeofTurfsController : ApiController
    {
        private TurfModelContainer1 db = new TurfModelContainer1();

        // GET: api/TypeofTurfs
        public IQueryable<TypeofTurf> GetTypeofTurfs()
        {
            return db.TypeofTurfs;
        }

        // GET: api/TypeofTurfs/5
        [ResponseType(typeof(TypeofTurf))]
        public async Task<IHttpActionResult> GetTypeofTurf(int id)
        {
            TypeofTurf typeofTurf = await db.TypeofTurfs.FindAsync(id);
            if (typeofTurf == null)
            {
                return NotFound();
            }

            return Ok(typeofTurf);
        }

        // PUT: api/TypeofTurfs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTypeofTurf(int id, TypeofTurf typeofTurf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeofTurf.Id)
            {
                return BadRequest();
            }

            db.Entry(typeofTurf).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeofTurfExists(id))
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

        // POST: api/TypeofTurfs
        [ResponseType(typeof(TypeofTurf))]
        public async Task<IHttpActionResult> PostTypeofTurf(TypeofTurf typeofTurf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeofTurfs.Add(typeofTurf);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = typeofTurf.Id }, typeofTurf);
        }

        // DELETE: api/TypeofTurfs/5
        [ResponseType(typeof(TypeofTurf))]
        public async Task<IHttpActionResult> DeleteTypeofTurf(int id)
        {
            TypeofTurf typeofTurf = await db.TypeofTurfs.FindAsync(id);
            if (typeofTurf == null)
            {
                return NotFound();
            }

            db.TypeofTurfs.Remove(typeofTurf);
            await db.SaveChangesAsync();

            return Ok(typeofTurf);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeofTurfExists(int id)
        {
            return db.TypeofTurfs.Count(e => e.Id == id) > 0;
        }
    }
}