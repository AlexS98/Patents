using System.Collections.Generic;
using System.Linq;

namespace Patents.Models.Repositories
{
    public class InventorsRepository : IInventorsRepository
    {
        private readonly EFDBContext context = new EFDBContext();
        public IEnumerable<Inventor> Inventors
        {
            get
            {
                return context.Inventors;
            }
        }

        public Inventor GetByName(string name)
        {
            return Inventors.FirstOrDefault(u => u.Name == name);
        }

        public void AddInventor(Inventor inventor)
        {
            context.Inventors.Add(inventor);
            context.SaveChanges();
        }
    }
}