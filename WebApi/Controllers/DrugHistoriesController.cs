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
    public class DrugHistoriesController : ApiController
    {
        private WebApiDbContext db = new WebApiDbContext();

        // GET: api/DrugHistories
        public IQueryable<DrugHistory> GetDrugHistory()
        {
            return db.DrugHistory;
        }

        // GET: api/DrugHistories/5
        [ResponseType(typeof(DrugHistory))]
        public async Task<IHttpActionResult> GetDrugHistory(int id)
        {
            DrugHistory drugHistory = await db.DrugHistory.FindAsync(id);
            if (drugHistory == null)
            {
                return NotFound();
            }

            return Ok(drugHistory);
        }

        // PUT: api/DrugHistories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDrugHistory(int id, DrugHistory drugHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drugHistory.RowId)
            {
                return BadRequest();
            }

            db.Entry(drugHistory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugHistoryExists(id))
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

        // POST: api/DrugHistories
        [ResponseType(typeof(DrugHistory))]
        public async Task<IHttpActionResult> PostDrugHistory(DrugHistory drugHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrugHistory.Add(drugHistory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = drugHistory.RowId }, drugHistory);
        }

        // DELETE: api/DrugHistories/5
        [ResponseType(typeof(DrugHistory))]
        public async Task<IHttpActionResult> DeleteDrugHistory(int id)
        {
            DrugHistory drugHistory = await db.DrugHistory.FindAsync(id);
            if (drugHistory == null)
            {
                return NotFound();
            }

            db.DrugHistory.Remove(drugHistory);
            await db.SaveChangesAsync();

            return Ok(drugHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrugHistoryExists(int id)
        {
            return db.DrugHistory.Count(e => e.RowId == id) > 0;
        }
    }
}