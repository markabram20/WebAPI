using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    public class PatientVisit
    {
        [Key]
        public int PatientVisitId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string CivilStatus { get; set; }
        public string HandedNess { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfConsultation { get; set; }
        public string PatientType { get; set; }
        public string GeneralPhysician { get; set; }
        public DateTime DateOfReferral { get; set; }
        public string Neurologist { get; set; }
        public DateTime DateOfReferralToPhysiatrist { get; set; }
        public string Physiatrist { get; set; }
        public DateTime DateOfIE { get; set; }
        public string Dx { get; set; }
        public string HPI { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        
    }
}
