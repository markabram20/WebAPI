namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "FirstName", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "LastName", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "DateOfBirth", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Patients", "CivilStatus", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "HandedNess", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "Gender", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "Occupation", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "Address", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "Religion", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "Nationality", c => c.String(unicode: false));
            DropColumn("dbo.Patients", "GeneralInfo_FirstName");
            DropColumn("dbo.Patients", "GeneralInfo_LastName");
            DropColumn("dbo.Patients", "GeneralInfo_DateOfBirth");
            DropColumn("dbo.Patients", "GeneralInfo_CivilStatus");
            DropColumn("dbo.Patients", "GeneralInfo_HandedNess");
            DropColumn("dbo.Patients", "GeneralInfo_Gender");
            DropColumn("dbo.Patients", "GeneralInfo_Occupation");
            DropColumn("dbo.Patients", "GeneralInfo_Address");
            DropColumn("dbo.Patients", "GeneralInfo_Religion");
            DropColumn("dbo.Patients", "GeneralInfo_Nationality");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "GeneralInfo_Nationality", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "GeneralInfo_Religion", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "GeneralInfo_Address", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "GeneralInfo_Occupation", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "GeneralInfo_Gender", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "GeneralInfo_HandedNess", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "GeneralInfo_CivilStatus", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "GeneralInfo_DateOfBirth", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Patients", "GeneralInfo_LastName", c => c.String(unicode: false));
            AddColumn("dbo.Patients", "GeneralInfo_FirstName", c => c.String(unicode: false));
            DropColumn("dbo.Patients", "Nationality");
            DropColumn("dbo.Patients", "Religion");
            DropColumn("dbo.Patients", "Address");
            DropColumn("dbo.Patients", "Occupation");
            DropColumn("dbo.Patients", "Gender");
            DropColumn("dbo.Patients", "HandedNess");
            DropColumn("dbo.Patients", "CivilStatus");
            DropColumn("dbo.Patients", "DateOfBirth");
            DropColumn("dbo.Patients", "LastName");
            DropColumn("dbo.Patients", "FirstName");
        }
    }
}
