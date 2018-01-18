using Patents.Models.Entities;
using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public class StatesRepository
    {
        private readonly EFDBContext context = new EFDBContext();
        public IEnumerable<State> State
        {
            get { return context.States; }
        }
    }
}