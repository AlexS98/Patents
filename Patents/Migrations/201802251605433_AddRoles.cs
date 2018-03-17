namespace Patents.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Roles",
                    c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        UserRole = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
        }
        
        public override void Down()
        {
        }
    }
}
