using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public class StatementsRepository
    {
        private readonly EFDBContext context = new EFDBContext();
        public IEnumerable<Request> Requests
        {
            get
            {
                return context.Requests;
            }
        }
    }
}