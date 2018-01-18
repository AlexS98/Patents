using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patents.Models.Repositories
{
    public class PatentsRepository : IPatentsRepository
    {
        private readonly EFDBContext context = new EFDBContext();
        public IEnumerable<Patent> Patents
        {
            get
            {
                var patents = context.Patents;              
                return patents;
            }
        }
    }
}