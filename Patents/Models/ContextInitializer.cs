using Patents.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Patents.Models
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<EFDBContext>
    {
        protected override void Seed(EFDBContext db)
        {
            List<Role> MyRoles = new List<Role>
            {
                new Role { UserRole = "Administrator" },
                new Role { UserRole = "Moderator" },
                new Role { UserRole = "Registred user" },
                new Role { UserRole = "Unregistred user" }
            };
            List<State> MyStates = new List<State>
            {
                new State { Info = "Expected" },
                new State { Info = "Completed" },
                new State { Info = "Canceled" }
            };
            db.Roles.AddRange(MyRoles);
            db.States.AddRange(MyStates);
            db.SaveChanges();
        }
    }
}