using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patents.Models.Repositories
{
    public interface IInventorsRepository
    {
        IEnumerable<Inventor> Inventors { get; }
        Inventor GetByName(string name);
        void AddInventor(Inventor inventor);
    }
}
