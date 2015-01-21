namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientAddressUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "CityTown", c => c.String());
            AddColumn("dbo.Patients", "Province", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Province");
            DropColumn("dbo.Patients", "CityTown");
        }
    }
}
