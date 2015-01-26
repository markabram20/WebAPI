namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PSEHx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientVisits", "PSEHx_FinancialStatus", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_PersonalityType", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_LifeStyle", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_EducationalAttainment", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_LivesWith", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_NumberOfOffspring", c => c.Int(nullable: false));
            AddColumn("dbo.PatientVisits", "PSEHx_Relatives", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_OtherLivesWith", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_Hobbies", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_Sports", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_OtherHobbies", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_CigaretteSmoker", c => c.Boolean(nullable: false));
            AddColumn("dbo.PatientVisits", "PSEHx_AlcoholDrinker", c => c.Boolean(nullable: false));
            AddColumn("dbo.PatientVisits", "PSEHx_TypeOfHouse", c => c.String());
            AddColumn("dbo.PatientVisits", "PSEHx_OtherTypeOfHouse", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientVisits", "PSEHx_OtherTypeOfHouse");
            DropColumn("dbo.PatientVisits", "PSEHx_TypeOfHouse");
            DropColumn("dbo.PatientVisits", "PSEHx_AlcoholDrinker");
            DropColumn("dbo.PatientVisits", "PSEHx_CigaretteSmoker");
            DropColumn("dbo.PatientVisits", "PSEHx_OtherHobbies");
            DropColumn("dbo.PatientVisits", "PSEHx_Sports");
            DropColumn("dbo.PatientVisits", "PSEHx_Hobbies");
            DropColumn("dbo.PatientVisits", "PSEHx_OtherLivesWith");
            DropColumn("dbo.PatientVisits", "PSEHx_Relatives");
            DropColumn("dbo.PatientVisits", "PSEHx_NumberOfOffspring");
            DropColumn("dbo.PatientVisits", "PSEHx_LivesWith");
            DropColumn("dbo.PatientVisits", "PSEHx_EducationalAttainment");
            DropColumn("dbo.PatientVisits", "PSEHx_LifeStyle");
            DropColumn("dbo.PatientVisits", "PSEHx_PersonalityType");
            DropColumn("dbo.PatientVisits", "PSEHx_FinancialStatus");
        }
    }
}
