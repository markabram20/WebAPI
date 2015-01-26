namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MissingMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientVisits", "FMHx_HypertensionF", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_HypertensionM", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_ArthritisF", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_ArthritisM", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_DiabetesMellitusF", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_DiabetesMellitusM", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_CancerF", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_CancerM", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_AsthmaF", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_AsthmaM", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_AllergiesF", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_AllergiesM", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_NeurologicConditionF", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_NeurologicConditionM", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_Others", c => c.String());
            AddColumn("dbo.PatientVisits", "FMHx_OthersF", c => c.Boolean());
            AddColumn("dbo.PatientVisits", "FMHx_OthersM", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientVisits", "FMHx_OthersM");
            DropColumn("dbo.PatientVisits", "FMHx_OthersF");
            DropColumn("dbo.PatientVisits", "FMHx_Others");
            DropColumn("dbo.PatientVisits", "FMHx_NeurologicConditionM");
            DropColumn("dbo.PatientVisits", "FMHx_NeurologicConditionF");
            DropColumn("dbo.PatientVisits", "FMHx_AllergiesM");
            DropColumn("dbo.PatientVisits", "FMHx_AllergiesF");
            DropColumn("dbo.PatientVisits", "FMHx_AsthmaM");
            DropColumn("dbo.PatientVisits", "FMHx_AsthmaF");
            DropColumn("dbo.PatientVisits", "FMHx_CancerM");
            DropColumn("dbo.PatientVisits", "FMHx_CancerF");
            DropColumn("dbo.PatientVisits", "FMHx_DiabetesMellitusM");
            DropColumn("dbo.PatientVisits", "FMHx_DiabetesMellitusF");
            DropColumn("dbo.PatientVisits", "FMHx_ArthritisM");
            DropColumn("dbo.PatientVisits", "FMHx_ArthritisF");
            DropColumn("dbo.PatientVisits", "FMHx_HypertensionM");
            DropColumn("dbo.PatientVisits", "FMHx_HypertensionF");
        }
    }
}
