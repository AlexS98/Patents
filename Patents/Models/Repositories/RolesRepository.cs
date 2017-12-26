using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public class RolesRepository
    {
        private readonly EFDBContext context = new EFDBContext();
        public IEnumerable<Role> Roles
        {
            get { return context.Roles; }
        }
    }
}