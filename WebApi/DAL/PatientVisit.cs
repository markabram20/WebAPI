﻿using System;
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

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [MaxLength(1)]
        public string Sex { get; set; }                     // Sex = [M|F]
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string CityTown { get; set; }
        [MaxLength(50)]
        public string Province { get; set; }
        [MaxLength(10)]
        public string CivilStatus { get; set; }
        [MaxLength(5)]
        public string HandedNess { get; set; }
        [MaxLength(50)]
        public string Occupation { get; set; }
        [MaxLength(50)]
        public string Religion { get; set; }
        //public string Nationality { get; set; } //Not included in latest doc: 1/3/2015
        [MaxLength(11)]
        public string PatientType { get; set; }
        
        public DateTime DateOfAdmission { get; set; }
        public DateTime DateOfConsultation { get; set; }
        [MaxLength(50)]
        public string Surgeon { get; set; }
        public DateTime DateOfSurgery { get; set; }
        
        [MaxLength(50)]
        public string GeneralPhysician { get; set; }
        [MaxLength(50)]
        public string Orthopedic { get; set; }
        [MaxLength(50)]
        public string Neurologist { get; set; }
        [MaxLength(50)]
        public string Cardiologist { get; set; }
        [MaxLength(50)]
        public string Opthalmologoist { get; set; }
        [MaxLength(50)]
        public string Pulmonologist { get; set; }
        [MaxLength(50)]
        public string OtherDoctor { get; set; }

        [MaxLength(50)]
        public string ReferringDoctor { get; set; }
        public DateTime DateOfReferral { get; set; }
        public DateTime DateOfInitialEvaluation { get; set; }

        public string Diagnosis { get; set; }
        
        public string HPI { get; set; }

        public PMHx PMHx { get; set; }
        public FMHx FMHx { get; set; }


        // Navigation Properties and Foreign Keys
        //

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public List<AncillaryProcedure> AncillayrProcedures { get; set; }
        public List<DrugHistory> DrugHistory { get; set; }
        
    }

    public class AncillaryProcedure
    {
        [Key]
        public int RowId { get; set; }
        [MaxLength(50)]
        public string ProcedureName { get; set; }
        public DateTime ProcedureDate { get; set; }
        [MaxLength(50)]
        public string Result { get; set; }

        [ForeignKey("PatientVisit")]
        public int PatientVisitId { get; set; }
        public PatientVisit PatientVisit { get; set; }
    }

    public class AncillaryProcedureTypes
    {
        public int ProcedureId { get; set; }
        [MaxLength(20)]
        public string ProcedureName { get; set; }
    }

    public class DrugHistory
    {
        [Key]
        public int RowId { get; set; }
        [MaxLength(50)]
        public string DrugName { get; set; }
        public DateTime DrugDate { get; set; }
        [MaxLength(50)]
        public string Result { get; set; }

        [ForeignKey("PatientVisit")]
        public int PatientVisitId { get; set; }
        public PatientVisit PatientVisit { get; set; }
    }

    [ComplexType]
    public class PMHx {
        [MaxLength(50)]
        public string Trauma { get; set; }
        public bool Arthritis { get; set; }
        public DateTime? Asthma { get; set; }
        public bool HPN { get; set; }
        [MaxLength(50)]
        public string DM { get; set; }
        public bool Allergies { get; set; }
        [MaxLength(50)]
        public string Surgery { get; set; }
        public DateTime? SurgeryDate { get; set; }
        [MaxLength(50)]
        public string Hopitalization { get; set; }
        public DateTime? HopitalizationDate { get; set; }
        [MaxLength(50)]
        public string CardiovascularDisease { get; set; }
        [MaxLength(50)]
        public string PulmonaryCondition { get; set; }
        [MaxLength(50)]
        public string NeurologyCondition { get; set; }
        public bool Cancer { get; set; }
        [MaxLength(50)]
        public string Others { get; set; }
    }

    [ComplexType]
    public class FMHx
    {
        public bool? HypertensionF { get; set; }
        public bool? HypertensionM { get; set; }
        public bool? ArthritisF { get; set; }
        public bool? ArthritisM { get; set; }
        public bool? DiabetesMellitusF { get; set; }
        public bool? DiabetesMellitusM { get; set; }
        public bool? CancerF { get; set; }
        public bool? CancerM { get; set; }
        public bool? AsthmaF { get; set; }
        public bool? AsthmaM { get; set; }
        public bool? AllergiesF { get; set; }
        public bool? AllergiesM { get; set; }
        public bool? NeurologicConditionF { get; set; }
        public bool? NeurologicConditionM { get; set; }
        public string Others { get; set; }
        public bool? OthersF { get; set; }
        public bool? OthersM { get; set; }
    }
}

