using Patents.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Patents.Models
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<EFDBContext>
    {
        protected override void Seed(EFDBContext db)
        {
            var myRoles = new List<Role>
            {
                new Role { UserRole = "Administrator" },
                new Role { UserRole = "Moderator" },
                new Role { UserRole = "Registred user" },
                new Role { UserRole = "Unregistred user" }
            };
            var myStates = new List<State>
            {
                new State { Info = "Expected" },
                new State { Info = "Completed" },
                new State { Info = "Canceled" }
            };
            db.Roles.AddRange(myRoles);
            db.States.AddRange(myStates);
            db.SaveChanges();
        }
    }
}