namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataInitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        CivilStatus = c.String(),
                        HandedNess = c.String(),
                        Gender = c.String(),
                        Occupation = c.String(),
                        Address = c.String(),
                        Religion = c.String(),
                        Nationality = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.PatientVisits",
                c => new
                    {
                        PatientVisitId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        CivilStatus = c.String(),
                        HandedNess = c.String(),
                        Gender = c.String(),
                        Occupation = c.String(),
                        Address = c.String(),
                        Religion = c.String(),
                        Nationality = c.String(),
                        DateOfConsultation = c.DateTime(nullable: false),
                        PatientType = c.String(),
                        GeneralPhysician = c.String(),
                        DateOfReferral = c.DateTime(nullable: false),
                        Neurologist = c.String(),
                        DateOfReferralToPhysiatrist = c.DateTime(nullable: false),
                        Physiatrist = c.String(),
                        DateOfIE = c.DateTime(nullable: false),
                        Dx = c.String(),
                        HPI = c.String(),
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
