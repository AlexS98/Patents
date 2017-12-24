using Patents.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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