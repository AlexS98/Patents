using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public interface IInventorsRepository
    {
        IEnumerable<Inventor> Inventors { get; }
        Inventor GetByName(string name);
        void AddInventor(Inventor inventor);
    }
}
