namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateTimeInSoap : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientVisits", "DateOfAdmission", c => c.DateTime());
            AlterColumn("dbo.PatientVisits", "DateOfConsultation", c => c.DateTime());
            AlterColumn("dbo.PatientVisits", "DateOfReferral", c => c.DateTime());
            AlterColumn("dbo.PatientVisits", "DateOfInitialEvaluation", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientVisits", "DateOfInitialEvaluation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientVisits", "DateOfReferral", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientVisits", "DateOfConsultation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientVisits", "DateOfAdmission", c => c.DateTime(nullable: false));
        }
    }
}
