namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Patient_Required_Info_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "LastName", c => c.String(unicode: false));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(unicode: false));
        }
    }
}
