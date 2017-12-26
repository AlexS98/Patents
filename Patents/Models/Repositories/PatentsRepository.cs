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
                var statements = new StatementsRepository().Statements;
                var inventors = new InventorsRepository().Inventors;
                var registers = new RegistersRepository().Registers;
                var ideas = new IdeasRepository().Ideas;
                foreach (var i in patents)
                {
                    foreach (var j in statements)
                    {
                        if (i.StatementId == j.StatementId)
                        {
                            i.Statement = j;
                            break;
                        }
                    }
                    foreach (var k in inventors)
                    {
                        if (i.InventorId == k.InventorId)
                        {
                            i.Inventor = k;
                            break;
                        }
                    }
                    foreach (var r in registers)
                    {
                        if (i.RegisterId == r.RegisterId)
                        {
                            i.Register = r;
                            break;
                        }
                    }
                    foreach (var d in ideas)
                    {
                        if (i.IdeaId == d.IdeaId)
                        {
                            i.Idea = d;
                            break;
                        }
                    }
                }
                return patents;
            }
        }
    }
}