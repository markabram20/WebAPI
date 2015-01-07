using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WebApiDbContext:DbContext
    {
        public WebApiDbContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientVisit> PatientVisits { get; set; }
        public DbSet<AncillaryProcedure> AncillaryProcedures { get; set; }
        public DbSet<DrugHistory> DrugHistory { get; set; }
    }
}
