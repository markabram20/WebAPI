namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class romupdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ROM2", "AromR", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROM2", "AromL", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROM2", "PromR", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROM2", "PromL", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROM2", "NormalValue", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROM2", "DifferenceR", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROM2", "DifferenceL", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROMs", "Arom", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROMs", "Prom", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROMs", "NormalValue", c => c.String(maxLength: 15));
            AlterColumn("dbo.ROMs", "Difference", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ROMs", "Difference", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROMs", "NormalValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROMs", "Prom", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROMs", "Arom", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROM2", "DifferenceL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROM2", "DifferenceR", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROM2", "NormalValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROM2", "PromL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROM2", "PromR", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROM2", "AromL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ROM2", "AromR", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
