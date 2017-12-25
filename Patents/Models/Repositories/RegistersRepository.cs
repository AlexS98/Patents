using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public class RegistersRepository
    {
        private EFDBContext context = new EFDBContext();
        public IEnumerable<Register> Registers
        {
            get
            {
                var reg = context.Registers;
                var roles = new RolesRepository().Roles;
                foreach (var i in reg)
                    foreach(var j in roles)
                        if(i.RoleId == j.RoleId) i.Role = j;
                return reg;
            }
        }
    }
}