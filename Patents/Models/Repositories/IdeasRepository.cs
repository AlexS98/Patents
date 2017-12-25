using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patents.Models.Repositories
{
    public class IdeasRepository
    {
        private EFDBContext context = new EFDBContext();
        public IEnumerable<Idea> Ideas
        {
            get
            {
                return context.Ideas;
            }
        }
    }
}