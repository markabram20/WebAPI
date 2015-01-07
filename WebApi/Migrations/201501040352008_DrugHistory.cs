namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrugHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrugHistories",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        DrugName = c.String(maxLength: 50),
                        DrugDate = c.DateTime(nullable: false),
                        Result = c.String(maxLength: 50),
                        PatientVisitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RowId)
                .ForeignKey("dbo.PatientVisits", t => t.PatientVisitId, cascadeDelete: true)
                .Index(t => t.PatientVisitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrugHistories", "PatientVisitId", "dbo.PatientVisits");
            DropIndex("dbo.DrugHistories", new[] { "PatientVisitId" });
            DropTable("dbo.DrugHistories");
        }
    }
}
