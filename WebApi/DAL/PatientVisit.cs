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
        public PatientVisit()
        {
            PMHx = new PMHx();
            FMHx = new FMHx();
            Patient = new Patient();
            PSEHx = new PSEHx();
            DateOfAdmission = null;
            DateOfConsultation = null;
            DateOfInitialEvaluation = null;
            DateOfReferral = null;
            DateOfSurgery = null;
        }

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
        
        public DateTime? DateOfAdmission { get; set; }
        public DateTime? DateOfConsultation { get; set; }
        [MaxLength(50)]
        public string Surgeon { get; set; }
        public DateTime? DateOfSurgery { get; set; }
        
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
        public DateTime? DateOfReferral { get; set; }
        public DateTime? DateOfInitialEvaluation { get; set; }

        public string Diagnosis { get; set; }
        
        public string HPI { get; set; }

        public string RomFindings { get; set; }
        public string RomSignificance { get; set; }

        public string MmtFindings { get; set; }
        public string MmtSignificance { get; set; }

        public string SensoryFindings { get; set; }
        public string SensorySignificance { get; set; }

        public string CranialNerveAssmtFindings { get; set; }
        public string CranialNerveAssmtSignificance { get; set; }

        public PMHx PMHx { get; set; }
        public FMHx FMHx { get; set; }
        public PSEHx PSEHx { get; set; }


        // Navigation Properties and Foreign Keys
        //

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public List<AncillaryProcedure> AncillaryProcedures { get; set; }
        public List<DrugHistory> DrugHistory { get; set; }
        public List<ROM> ROMs { get; set; }
        public List<ROM2> ROM2s { get; set; }
        public List<MMT> MMTs { get; set; }
        public List<SensoryAx> SensoryAxs { get; set; }
        public List<CranialNerveAssmt> CranialNerveAssmts { get; set; }
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

        //[ForeignKey("PatientVisit")]
        public int PatientVisitId { get; set; }
        //public PatientVisit PatientVisit { get; set; }
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

        //[ForeignKey("PatientVisit")]
        public int PatientVisitId { get; set; }
        //public PatientVisit PatientVisit { get; set; }
    }

    //[ComplexType]
    public class PMHx
    {
        public bool Trauma { get; set; }
        [MaxLength(50)]
        public string TraumaText { get; set; }
        public bool Arthritis { get; set; }
        [MaxLength(50)]
        public string ArthritisText { get; set; }
        public bool Asthma { get; set; }
        public DateTime? AsthmaDate { get; set; }
        public bool HPN { get; set; }
        public bool DM { get; set; }
        [MaxLength(50)]
        public string DMText { get; set; }
        public bool Allergies { get; set; }
        public bool Surgery { get; set; }
        [MaxLength(50)]
        public string SurgeryText { get; set; }
        public DateTime? SurgeryDate { get; set; }
        public bool Hospitalization { get; set; }
        [MaxLength(50)]
        public string HospitalizationText { get; set; }
        public DateTime? HospitalizationDate { get; set; }
        public bool CardiovascularDisease { get; set; }
        [MaxLength(50)]
        public string CardiovascularDiseaseText { get; set; }
        public bool PulmonaryCondition { get; set; }
        [MaxLength(50)]
        public string PulmonaryConditionText { get; set; }
        public bool NeurologyCondition { get; set; }
        [MaxLength(50)]
        public string NeurologyConditionText { get; set; }
        public bool Cancer { get; set; }
        [MaxLength(50)]
        public string Others { get; set; }
    }

    [ComplexType]
    public class FMHx
    {
        public bool HypertensionF { get; set; }
        public bool HypertensionM { get; set; }
        public bool ArthritisF { get; set; }
        public bool ArthritisM { get; set; }
        public bool DiabetesMellitusF { get; set; }
        public bool DiabetesMellitusM { get; set; }
        public bool CancerF { get; set; }
        public bool CancerM { get; set; }
        public bool AsthmaF { get; set; }
        public bool AsthmaM { get; set; }
        public bool AllergiesF { get; set; }
        public bool AllergiesM { get; set; }
        public bool NeurologicConditionF { get; set; }
        public bool NeurologicConditionM { get; set; }
        [MaxLength(50)]
        public string Others { get; set; }
        public bool OthersF { get; set; }
        public bool OthersM { get; set; }
    }

    [ComplexType]
    public class PSEHx
    {
        [MaxLength(50)]
        public string FinancialStatus { get; set; }
        [MaxLength(50)]
        public string PersonalityType { get; set; }
        [MaxLength(50)]
        public string LifeStyle { get; set; }
        [MaxLength(50)]
        public string EducationalAttainment { get; set; }
        [MaxLength(50)]
        public string LivesWith { get; set; }
        public int NumberOfOffspring { get; set; }
        [MaxLength(50)]
        public string Relatives {get;set;}
        [MaxLength(50)]
        public string OtherLivesWith { get; set; }
        [MaxLength(50)]
        public string Hobbies { get; set; }
        [MaxLength(50)]
        public string Sports { get; set; }
        [MaxLength(50)]
        public string OtherHobbies { get; set; }
        public bool CigaretteSmoker { get; set; }
        public bool AlcoholDrinker { get; set; }
        [MaxLength(50)]
        public string TypeOfHouse { get; set; }
        [MaxLength(50)]
        public string OtherTypeOfHouse { get; set; }
    }

    public class SubjectiveObjective
    {
        [MaxLength(200)]
        public string ChiefComplaint { get; set; }
        [MaxLength(200)]
        public string PtTranslation { get; set; }
        [MaxLength(20)]
        public string BPBefore { get; set; }
        [MaxLength(20)]
        public string BPAfter { get; set; }
        [MaxLength(20)]
        public string RRBefore { get; set; }
        [MaxLength(20)]
        public string RRAfter { get; set; }
        [MaxLength(20)]
        public string PRBefore { get; set; }
        [MaxLength(20)]
        public string PRAfter { get; set; }
        [MaxLength(20)]
        public string TBefore { get; set; }
        [MaxLength(20)]
        public string TAfter { get; set; }
        [MaxLength(200)]
        public string Findings { get; set; }
        [MaxLength(200)]
        public string Significance { get; set; }
    }

    public class OcularInspection
    {
        public bool Ambulation { get; set; }
        public bool TADWheelChair { get; set; }
        [MaxLength(20)]
        public string TADCruches { get; set; }
        [MaxLength(20)]
        public string TADCane { get; set; }
        [MaxLength(20)]
        public string TADWalker { get; set; }
        public bool Alert { get; set; }
        public bool Coherent { get; set; }
        public bool Cooperative { get; set; }
        [MaxLength(20)]
        public string BodyType { get; set; }
        [MaxLength(50)]
        public string Atrophy { get; set; }
        [MaxLength(50)]
        public string Swelling { get; set; }
        [MaxLength(50)]
        public string Redness { get; set; }
        [MaxLength(50)]
        public string Ecchymosis { get; set; }
        [MaxLength(50)]
        public string Deformity { get; set; }
        [MaxLength(50)]
        public string Wounds { get; set; }
        [MaxLength(50)]
        public string Scar { get; set; }
        [MaxLength(50)]
        public string PressureSore { get; set; }
        public bool GaitDeviation { get; set; }
        [MaxLength(50)]
        public string Incision { get; set; }
        public bool ShortnessOfBreathing { get; set; }
        [MaxLength(50)]
        public string Others { get; set; }
    }

    public class Palpation
    {
        [MaxLength(20)]
        public string BodyTemperature { get; set; }
        [MaxLength(20)]
        public string MuscleTone { get; set; }
        [MaxLength(20)]
        public string Edema { get; set; }
        [MaxLength(20)]
        public string Tenderness { get; set; }
        [MaxLength(20)]
        public string Location { get; set; }
        [MaxLength(20)]
        public string Deformity { get; set; }
        public bool MuscleGuarding { get; set; }
        public bool MuscleSpasm { get; set; }
        public bool Subluxation { get; set; }
        public bool Dislocation { get; set; }
    }

    public class ROM
    {
        [Key]
        public int RowId { get; set; }
        [MaxLength(100)]
        public string Motion { get; set; }
        public decimal Arom { get; set; }
        public decimal Prom { get; set; }
        public decimal NormalValue { get; set; }
        public decimal Difference { get; set; }
        [MaxLength(20)]
        public string EndFeel { get; set; }
        public int PatientVisitId { get; set; }
    }

    public class ROM2
    {
        [Key]
        public int RowId { get; set; }
        [MaxLength(100)]
        public string Motion { get; set; }
        public decimal AromR { get; set; }
        public decimal AromL { get; set; }
        public decimal PromR { get; set; }
        public decimal PromL { get; set; }
        public decimal NormalValue { get; set; }
        public decimal DifferenceR { get; set; }
        public decimal DifferenceL { get; set; }
        [MaxLength(20)]
        public string EndFeel { get; set; }
        public int PatientVisitId { get; set; }
    }

    public class MMT
    {
        [Key]
        public int RowId { get; set; }
        [MaxLength(100)]
        public string Motion { get; set; }
        public decimal GradeR { get; set; }
        public decimal GraderL { get; set; }
        public int PatientVisitId { get; set; }
    }

    public class SensoryAx
    {
        [Key]
        public int RowId { get; set; }
        [MaxLength(100)]
        public string MaterialUsed { get; set; }
        [MaxLength(100)]
        public string Landmarks { get; set; }
        [MaxLength(50)]
        public string Result { get; set; }
        public int PatientVisitId { get; set; }
    }

    public class CranialNerveAssmt
    {
        [Key]
        public int RowId { get; set; }
        [MaxLength(2)]
        public string Right { get; set; }
        [MaxLength(2)]
        public string Left { get; set; }
        [MaxLength(50)]
        public string Result { get; set; }
        public int PatientVisitId { get; set; }
    }
}
