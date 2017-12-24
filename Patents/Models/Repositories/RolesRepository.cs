using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patents.Models.Repositories
{
    public class RolesRepository
    {
        private EFDBContext context = new EFDBContext();
        public IEnumerable<Role> Roles
        {
            get { return context.Roles; }
        }
    }
}