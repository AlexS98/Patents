using Patents.Models.Entities;
using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public class StateRepository
    {
        private EFDBContext context = new EFDBContext();
        public IEnumerable<State> States
        {
            get { return context.States; }
        }
    }
}