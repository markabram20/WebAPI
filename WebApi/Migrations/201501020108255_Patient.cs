namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Patient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        GeneralInfo_FirstName = c.String(unicode: false),
                        GeneralInfo_LastName = c.String(unicode: false),
                        GeneralInfo_DateOfBirth = c.DateTime(nullable: false, precision: 0),
                        GeneralInfo_CivilStatus = c.String(unicode: false),
                        GeneralInfo_HandedNess = c.String(unicode: false),
                        GeneralInfo_Gender = c.String(unicode: false),
                        GeneralInfo_Occupation = c.String(unicode: false),
                        GeneralInfo_Address = c.String(unicode: false),
                        GeneralInfo_Religion = c.String(unicode: false),
                        GeneralInfo_Nationality = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.PatientVisits",
                c => new
                    {
                        PatientVisitId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Age = c.Int(nullable: false),
                        CivilStatus = c.String(unicode: false),
                        HandedNess = c.String(unicode: false),
                        Gender = c.String(unicode: false),
                        Occupation = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        Religion = c.String(unicode: false),
                        Nationality = c.String(unicode: false),
                        DateOfConsultation = c.DateTime(nullable: false, precision: 0),
                        PatientType = c.String(unicode: false),
                        GeneralPhysician = c.String(unicode: false),
                        DateOfReferral = c.DateTime(nullable: false, precision: 0),
                        Neurologist = c.String(unicode: false),
                        DateOfReferralToPhysiatrist = c.DateTime(nullable: false, precision: 0),
                        Physiatrist = c.String(unicode: false),
                        DateOfIE = c.DateTime(nullable: false, precision: 0),
                        Dx = c.String(unicode: false),
                        HPI = c.String(unicode: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientVisitId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientVisits", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientVisits", new[] { "PatientId" });
            DropTable("dbo.PatientVisits");
            DropTable("dbo.Patients");
        }
    }
}
