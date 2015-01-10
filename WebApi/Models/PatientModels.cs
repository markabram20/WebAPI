using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PatientModel
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CivilStatus { get; set; }
        public string HandedNess { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
    }

    public class PatientListItem {
        public int PatientId { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public DateTime? LastVisit { get; set; }
    }
}
