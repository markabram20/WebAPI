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
using WebApi.DAL;

namespace WebApi.Controllers
{
    public class CranialNerveAssmtsController : ApiController
    {
        private WebApiDbContext db = new WebApiDbContext();

        // GET: api/CranialNerveAssmts
        public IQueryable<CranialNerveAssmt> GetCranialNerveAssmts()
        {
            return db.CranialNerveAssmts;
        }

        // GET: api/CranialNerveAssmts/5
        [ResponseType(typeof(CranialNerveAssmt))]
        public async Task<IHttpActionResult> GetCranialNerveAssmt(int id)
        {
            CranialNerveAssmt cranialNerveAssmt = await db.CranialNerveAssmts.FindAsync(id);
            if (cranialNerveAssmt == null)
            {
                return NotFound();
            }

            return Ok(cranialNerveAssmt);
        }

        // PUT: api/CranialNerveAssmts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCranialNerveAssmt(int id, CranialNerveAssmt cranialNerveAssmt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cranialNerveAssmt.RowId)
            {
                return BadRequest();
            }

            db.Entry(cranialNerveAssmt).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CranialNerveAssmtExists(id))
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

        // POST: api/CranialNerveAssmts
        [ResponseType(typeof(CranialNerveAssmt))]
        public async Task<IHttpActionResult> PostCranialNerveAssmt(CranialNerveAssmt cranialNerveAssmt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CranialNerveAssmts.Add(cranialNerveAssmt);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cranialNerveAssmt.RowId }, cranialNerveAssmt);
        }

        // DELETE: api/CranialNerveAssmts/5
        [ResponseType(typeof(CranialNerveAssmt))]
        public async Task<IHttpActionResult> DeleteCranialNerveAssmt(int id)
        {
            CranialNerveAssmt cranialNerveAssmt = await db.CranialNerveAssmts.FindAsync(id);
            if (cranialNerveAssmt == null)
            {
                return NotFound();
            }

            db.CranialNerveAssmts.Remove(cranialNerveAssmt);
            await db.SaveChangesAsync();

            return Ok(cranialNerveAssmt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CranialNerveAssmtExists(int id)
        {
            return db.CranialNerveAssmts.Count(e => e.RowId == id) > 0;
        }
    }
}