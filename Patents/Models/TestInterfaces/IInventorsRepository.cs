using System.Collections.Generic;
using Patents.Models.Entities;

namespace Patents.Models.TestInterfaces
{
    public interface IInventorsRepository
    {
        IEnumerable<Inventor> Inventors { get; }
        Inventor GetByName(string name);
        void AddInventor(Inventor inventor);
    }
}
