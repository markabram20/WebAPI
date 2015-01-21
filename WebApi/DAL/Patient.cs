using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CivilStatus { get; set; }
        public string HandedNess { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string CityTown { get; set; }
        public string Province { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }

        public List<PatientVisit> PatientVisits { get; set; }
    }
}
