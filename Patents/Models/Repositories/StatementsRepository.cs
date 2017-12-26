using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public class StatementsRepository
    {
        private readonly EFDBContext context = new EFDBContext();
        public IEnumerable<Statement> Statements
        {
            get
            {
                var statements = context.Statements;
                var state = new StatesRepository().States;
                foreach (var i in statements)
                {
                    foreach (var j in state)
                    {
                        if (i.StateId == j.StateId) { i.State = j; }
                    }
                }
                return statements;
            }
        }
    }
}