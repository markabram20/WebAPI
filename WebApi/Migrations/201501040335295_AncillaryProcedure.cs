namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AncillaryProcedure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AncillaryProcedures",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        ProcedureName = c.String(maxLength: 50),
                        ProcedureDate = c.DateTime(nullable: false),
                        Result = c.String(maxLength: 50),
                        PatientVisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RowId)
                .ForeignKey("dbo.PatientVisits", t => t.PatientVisitId, cascadeDelete: true)
                .Index(t => t.PatientVisitId);
            
            AddColumn("dbo.PatientVisits", "Sex", c => c.String(maxLength: 1));
            AddColumn("dbo.PatientVisits", "CityTown", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "Province", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "DateOfAdmission", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientVisits", "Surgeon", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "DateOfSurgery", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientVisits", "Orthopedic", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "Cardiologist", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "Opthalmologoist", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "Pulmonologist", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "OtherDoctor", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "ReferringDoctor", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "DateOfInitialEvaluation", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientVisits", "Diagnosis", c => c.String());
            AlterColumn("dbo.PatientVisits", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PatientVisits", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PatientVisits", "CivilStatus", c => c.String(maxLength: 10));
            AlterColumn("dbo.PatientVisits", "HandedNess", c => c.String(maxLength: 5));
            AlterColumn("dbo.PatientVisits", "Occupation", c => c.String(maxLength: 50));
            AlterColumn("dbo.PatientVisits", "Address", c => c.String(maxLength: 150));
            AlterColumn("dbo.PatientVisits", "Religion", c => c.String(maxLength: 50));
            AlterColumn("dbo.PatientVisits", "PatientType", c => c.String(maxLength: 11));
            AlterColumn("dbo.PatientVisits", "GeneralPhysician", c => c.String(maxLength: 50));
            AlterColumn("dbo.PatientVisits", "Neurologist", c => c.String(maxLength: 50));
            DropColumn("dbo.PatientVisits", "Gender");
            DropColumn("dbo.PatientVisits", "Nationality");
            DropColumn("dbo.PatientVisits", "DateOfReferralToPhysiatrist");
            DropColumn("dbo.PatientVisits", "Physiatrist");
            DropColumn("dbo.PatientVisits", "DateOfIE");
            DropColumn("dbo.PatientVisits", "Dx");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientVisits", "Dx", c => c.String());
            AddColumn("dbo.PatientVisits", "DateOfIE", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientVisits", "Physiatrist", c => c.String());
            AddColumn("dbo.PatientVisits", "DateOfReferralToPhysiatrist", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientVisits", "Nationality", c => c.String());
            AddColumn("dbo.PatientVisits", "Gender", c => c.String());
            DropForeignKey("dbo.AncillaryProcedures", "PatientVisitId", "dbo.PatientVisits");
            DropIndex("dbo.AncillaryProcedures", new[] { "PatientVisitId" });
            AlterColumn("dbo.PatientVisits", "Neurologist", c => c.String());
            AlterColumn("dbo.PatientVisits", "GeneralPhysician", c => c.String());
            AlterColumn("dbo.PatientVisits", "PatientType", c => c.String());
            AlterColumn("dbo.PatientVisits", "Religion", c => c.String());
            AlterColumn("dbo.PatientVisits", "Address", c => c.String());
            AlterColumn("dbo.PatientVisits", "Occupation", c => c.String());
            AlterColumn("dbo.PatientVisits", "HandedNess", c => c.String());
            AlterColumn("dbo.PatientVisits", "CivilStatus", c => c.String());
            AlterColumn("dbo.PatientVisits", "LastName", c => c.String());
            AlterColumn("dbo.PatientVisits", "FirstName", c => c.String());
            DropColumn("dbo.PatientVisits", "Diagnosis");
            DropColumn("dbo.PatientVisits", "DateOfInitialEvaluation");
            DropColumn("dbo.PatientVisits", "ReferringDoctor");
            DropColumn("dbo.PatientVisits", "OtherDoctor");
            DropColumn("dbo.PatientVisits", "Pulmonologist");
            DropColumn("dbo.PatientVisits", "Opthalmologoist");
            DropColumn("dbo.PatientVisits", "Cardiologist");
            DropColumn("dbo.PatientVisits", "Orthopedic");
            DropColumn("dbo.PatientVisits", "DateOfSurgery");
            DropColumn("dbo.PatientVisits", "Surgeon");
            DropColumn("dbo.PatientVisits", "DateOfAdmission");
            DropColumn("dbo.PatientVisits", "Province");
            DropColumn("dbo.PatientVisits", "CityTown");
            DropColumn("dbo.PatientVisits", "Sex");
            DropTable("dbo.AncillaryProcedures");
        }
    }
}
