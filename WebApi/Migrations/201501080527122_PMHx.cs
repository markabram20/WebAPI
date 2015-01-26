namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PMHx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientVisits", "PMHx_Trauma", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "PMHx_Arthritis", c => c.Boolean(nullable: false));
            AddColumn("dbo.PatientVisits", "PMHx_Asthma", c => c.DateTime());
            AddColumn("dbo.PatientVisits", "PMHx_HPN", c => c.Boolean(nullable: false));
            AddColumn("dbo.PatientVisits", "PMHx_DM", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "PMHx_Allergies", c => c.Boolean(nullable: false));
            AddColumn("dbo.PatientVisits", "PMHx_Surgery", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "PMHx_SurgeryDate", c => c.DateTime());
            AddColumn("dbo.PatientVisits", "PMHx_Hopitalization", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "PMHx_HopitalizationDate", c => c.DateTime());
            AddColumn("dbo.PatientVisits", "PMHx_CardiovascularDisease", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "PMHx_PulmonaryCondition", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "PMHx_NeurologyCondition", c => c.String(maxLength: 50));
            AddColumn("dbo.PatientVisits", "PMHx_Cancer", c => c.Boolean(nullable: false));
            AddColumn("dbo.PatientVisits", "PMHx_Others", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientVisits", "PMHx_Others");
            DropColumn("dbo.PatientVisits", "PMHx_Cancer");
            DropColumn("dbo.PatientVisits", "PMHx_NeurologyCondition");
            DropColumn("dbo.PatientVisits", "PMHx_PulmonaryCondition");
            DropColumn("dbo.PatientVisits", "PMHx_CardiovascularDisease");
            DropColumn("dbo.PatientVisits", "PMHx_HopitalizationDate");
            DropColumn("dbo.PatientVisits", "PMHx_Hopitalization");
            DropColumn("dbo.PatientVisits", "PMHx_SurgeryDate");
            DropColumn("dbo.PatientVisits", "PMHx_Surgery");
            DropColumn("dbo.PatientVisits", "PMHx_Allergies");
            DropColumn("dbo.PatientVisits", "PMHx_DM");
            DropColumn("dbo.PatientVisits", "PMHx_HPN");
            DropColumn("dbo.PatientVisits", "PMHx_Asthma");
            DropColumn("dbo.PatientVisits", "PMHx_Arthritis");
            DropColumn("dbo.PatientVisits", "PMHx_Trauma");
        }
    }
}
