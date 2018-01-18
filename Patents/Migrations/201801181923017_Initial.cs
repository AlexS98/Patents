namespace Patents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ideas",
                c => new
                    {
                        IdeaId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        References = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdeaId);
            
            CreateTable(
                "dbo.Inventors",
                c => new
                    {
                        InventorId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InventorId);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        MeetingId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Additions = c.String(),
                        InventorId = c.Int(nullable: false),
                        RegisterId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MeetingId)
                .ForeignKey("dbo.Inventors", t => t.InventorId, cascadeDelete: false)
                .ForeignKey("dbo.Registers", t => t.RegisterId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .Index(t => t.InventorId)
                .Index(t => t.RegisterId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        RegisterId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegisterId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        UserRole = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        Info = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.Patents",
                c => new
                    {
                        PatentId = c.Int(nullable: false, identity: true),
                        InventorId = c.Int(nullable: false),
                        RegisterId = c.Int(nullable: false),
                        IdeaId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatentId)
                .ForeignKey("dbo.Ideas", t => t.IdeaId, cascadeDelete: false)
                .ForeignKey("dbo.Inventors", t => t.InventorId, cascadeDelete: false)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: false)
                .ForeignKey("dbo.Registers", t => t.RegisterId, cascadeDelete: false)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: false)
                .Index(t => t.InventorId)
                .Index(t => t.RegisterId)
                .Index(t => t.IdeaId)
                .Index(t => t.RequestId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDetails = c.String(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        SubmitDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        ConsidDate = c.DateTime(nullable: false),
                        DenialReason = c.String(),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patents", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Requests", "StateId", "dbo.States");
            DropForeignKey("dbo.Patents", "RegisterId", "dbo.Registers");
            DropForeignKey("dbo.Patents", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Payments", "StateId", "dbo.States");
            DropForeignKey("dbo.Patents", "InventorId", "dbo.Inventors");
            DropForeignKey("dbo.Patents", "IdeaId", "dbo.Ideas");
            DropForeignKey("dbo.Meetings", "StateId", "dbo.States");
            DropForeignKey("dbo.Meetings", "RegisterId", "dbo.Registers");
            DropForeignKey("dbo.Registers", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Meetings", "InventorId", "dbo.Inventors");
            DropIndex("dbo.Requests", new[] { "StateId" });
            DropIndex("dbo.Payments", new[] { "StateId" });
            DropIndex("dbo.Patents", new[] { "PaymentId" });
            DropIndex("dbo.Patents", new[] { "RequestId" });
            DropIndex("dbo.Patents", new[] { "IdeaId" });
            DropIndex("dbo.Patents", new[] { "RegisterId" });
            DropIndex("dbo.Patents", new[] { "InventorId" });
            DropIndex("dbo.Registers", new[] { "RoleId" });
            DropIndex("dbo.Meetings", new[] { "StateId" });
            DropIndex("dbo.Meetings", new[] { "RegisterId" });
            DropIndex("dbo.Meetings", new[] { "InventorId" });
            DropTable("dbo.Requests");
            DropTable("dbo.Payments");
            DropTable("dbo.Patents");
            DropTable("dbo.States");
            DropTable("dbo.Roles");
            DropTable("dbo.Registers");
            DropTable("dbo.Meetings");
            DropTable("dbo.Inventors");
            DropTable("dbo.Ideas");
        }
    }
}
