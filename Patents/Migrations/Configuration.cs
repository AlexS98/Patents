using Patents.Models;
using Patents.Models.Entities;

namespace Patents.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Patents.Models.EFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFDBContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            db.Roles.AddOrUpdate(
                new Role { UserRole = "Administrator" },
                new Role { UserRole = "Moderator" },
                new Role { UserRole = "Registred user" },
                new Role { UserRole = "Unregistred user" });
            db.States.AddOrUpdate(
                new State { Info = "Expected" },
                new State { Info = "Completed" },
                new State { Info = "Canceled" });
        }
    }
}
