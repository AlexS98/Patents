namespace Patents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "InventorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "InventorId");
            AddForeignKey("dbo.Payments", "InventorId", "dbo.Inventors", "InventorId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "InventorId", "dbo.Inventors");
            DropIndex("dbo.Payments", new[] { "InventorId" });
            DropColumn("dbo.Payments", "InventorId");
        }
    }
