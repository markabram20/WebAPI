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
    public class SoapListController : ApiController
    {
        private WebApiDbContext db = new WebApiDbContext();

        // GET: api/PatientsList/id

        public IQueryable<SoapListItem> GetSoapList(int id)
        {
            return db.PatientVisits.Where(x => x.PatientId == id).Select(x => new SoapListItem() {
                PatientVisitId = x.PatientVisitId,
                Date = x.DateOfConsultation
            });
        }
    }
}
