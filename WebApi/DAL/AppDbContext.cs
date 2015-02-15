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

        public System.Data.Entity.DbSet<WebApi.DAL.ROM> ROMs { get; set; }

        public System.Data.Entity.DbSet<WebApi.DAL.ROM2> ROM2 { get; set; }

        public System.Data.Entity.DbSet<WebApi.DAL.MMT> MMTs { get; set; }

        public System.Data.Entity.DbSet<WebApi.DAL.SensoryAx> SensoryAxes { get; set; }

        public System.Data.Entity.DbSet<WebApi.DAL.CranialNerveAssmt> CranialNerveAssmts { get; set; }

        public System.Data.Entity.DbSet<WebApi.DAL.CoordinationAssmt> CoordinationAssmts { get; set; }

        public System.Data.Entity.DbSet<WebApi.DAL.MBM> MBMs { get; set; }
    }
}
