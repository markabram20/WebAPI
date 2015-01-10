using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DAL;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PatientsListController : ApiController
    {
        private WebApiDbContext db = new WebApiDbContext();

        // GET: api/PatientsList
        public IQueryable<PatientListItem> GetPatientsList()
        {
            return db.Patients.Select(x => new PatientListItem() { PatientId = x.PatientId, DisplayName = x.FirstName + " " + x.LastName, Address = x.Address });
        }
    }
}
