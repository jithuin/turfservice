using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using websvc.Models;


namespace websvc.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    public class TurfUsersController : ApiController
    {
        private TurfModelContainer1 db = new TurfModelContainer1();

        // GET: api/TurfUsers
        public IQueryable<TurfUser> GetTurfUsers()
        {
            return db.TurfUsers;
        }

        // GET: api/TurfUsers/5
        [ResponseType(typeof(TurfUser))]
        [Authorize]
        public async Task<IHttpActionResult> GetTurfUser(int id)
        {
            TurfUser turfUser = await db.TurfUsers.FindAsync(id);
            if (turfUser == null)
            {
                return NotFound();
            }

            return Ok(turfUser);
        }

        // PUT: api/TurfUsers/5
        [ResponseType(typeof(void))]
        [Authorize]
        public async Task<IHttpActionResult> PutTurfUser(int id, TurfUser turfUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turfUser.Id)
            {
                return BadRequest();
            }

            db.Entry(turfUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurfUserExists(id))
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

        // POST: api/TurfUsers
        [ResponseType(typeof(TurfUser))]
        public async Task<IHttpActionResult> PostTurfUser(TurfUser turfUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TurfUsers.Add(turfUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = turfUser.Id }, turfUser);
        }

        // DELETE: api/TurfUsers/5
        [ResponseType(typeof(TurfUser))]
        [Authorize]
        public async Task<IHttpActionResult> DeleteTurfUser(int id)
        {
            TurfUser turfUser = await db.TurfUsers.FindAsync(id);
            if (turfUser == null)
            {
                return NotFound();
            }

            db.TurfUsers.Remove(turfUser);
            await db.SaveChangesAsync();

            return Ok(turfUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurfUserExists(int id)
        {
            return db.TurfUsers.Count(e => e.Id == id) > 0;
        }
    }
}