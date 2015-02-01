using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.DAL;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PatientVisitsController : ApiController
    {
        private WebApiDbContext db = new WebApiDbContext();

        // GET: api/PatientVisits
        public IQueryable<PatientVisit> GetPatientVisits()
        {
            return db.PatientVisits;
        }

        // GET: api/PatientVisits/5
        [ResponseType(typeof(PatientVisit))]
        public async Task<IHttpActionResult> GetPatientVisit(int id)
        {
            PatientVisit patientVisit = await db.PatientVisits
                .Include(x=>x.DrugHistory)
                .Include(x=>x.AncillaryProcedures)
                .Include(x=>x.ROMs)
                .Include(x=>x.ROM2s)
                .Include(x=>x.MMTs)
                .Include(x=>x.SensoryAxs)
                .Where(x=>x.PatientVisitId == id).FirstOrDefaultAsync();
            if (patientVisit == null)
            {
                return NotFound();
            }

            return Ok(patientVisit);
        }

        // PUT: api/PatientVisits/5
        [ResponseType(typeof(void))]
        [IgnoreModelErrors("Patient.*")]
        [IgnoreModelErrors("DrugHistory.PatientVisitId")]
        public async Task<IHttpActionResult> PutPatientVisit(int id, PatientVisit patientVisit)
        {
            patientVisit.Patient = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientVisit.PatientVisitId)
            {
                return BadRequest();
            }

            List<DrugHistory> drugs = new List<DrugHistory>();
            
            foreach (var d in patientVisit.DrugHistory)
                drugs.Add(d);
            
            // from db
            var oDrg = db.DrugHistory.Where(x => x.PatientVisitId == patientVisit.PatientVisitId).ToList();
            
            patientVisit.DrugHistory = null;
            var entry = db.Entry(patientVisit);
            entry.State = EntityState.Modified;
            //entry.Collection(x => x.DrugHistory).EntityEntry.State = EntityState.Detached;
                       

            // to be deleted
            var delDrg = oDrg.Where(x => !drugs.Any(y => y.RowId == x.RowId)).ToList();
            foreach(var d in delDrg){
                db.DrugHistory.Remove(d);
            }

            // to be edited
            foreach (var drug in drugs)
            {
                if (oDrg.Where(x => x.RowId == drug.RowId).Count() < 1)
                    db.Entry(drug).State = EntityState.Added;
                else
                    entry.Collection(x => x.DrugHistory).EntityEntry.State = EntityState.Modified;
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientVisitExists(id))
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

        // POST: api/PatientVisits
        //[HttpPost]
        //[Route("api/Soap/Add")]
        [ResponseType(typeof(PatientVisit))]
        [IgnoreModelErrors("Patient.*")]
        public async Task<IHttpActionResult> PostPatientVisit(PatientVisit patientVisit)
        {
            try
            {
                patientVisit.Patient = null;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.PatientVisits.Add(patientVisit);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = patientVisit.PatientVisitId }, patientVisit);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        // DELETE: api/PatientVisits/5
        [ResponseType(typeof(PatientVisit))]
        public async Task<IHttpActionResult> DeletePatientVisit(int id)
        {
            try
            {
                PatientVisit patientVisit = await db.PatientVisits.FindAsync(id);
                if (patientVisit == null)
                {
                    return NotFound();
                }
                
                patientVisit.Patient = null;

                db.PatientVisits.Remove(patientVisit);
                
                await db.SaveChangesAsync();

                return Ok(patientVisit);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientVisitExists(int id)
        {
            return db.PatientVisits.Count(e => e.PatientVisitId == id) > 0;
        }
    }
}