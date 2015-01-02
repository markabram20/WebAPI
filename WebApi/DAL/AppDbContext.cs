using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WebApiDbContext:DbContext
    {
        public WebApiDbContext()
            : base("WebApiDataConnection")
        {
            
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientVisit> PatientVisits { get; set; }
    }
}
