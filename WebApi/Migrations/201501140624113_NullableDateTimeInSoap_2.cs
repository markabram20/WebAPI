namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateTimeInSoap_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientVisits", "DateOfSurgery", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientVisits", "DateOfSurgery", c => c.DateTime(nullable: false));
        }
    }
}
