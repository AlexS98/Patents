using System;
using System.Collections.Generic;
using System.Linq;

namespace Patents.Models.Repositories
{
    public class InventorsRepository : IGenericRepository<Inventor>
    {
        private readonly EFDBContext context = new EFDBContext();
        public IEnumerable<Inventor> Inventors;
        public InventorsRepository()
        {
            Inventors = context.Inventors;
        }

        public Inventor GetByName(string name)
        {
            return Inventors.FirstOrDefault(u => u.FullName == name);
        }

        public void AddInventor(Inventor inventor)
        {
            context.Inventors.Add(inventor);
            context.SaveChanges();
        }

        public void Create(Inventor item)
        {
            throw new NotImplementedException();
        }

        public Inventor FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventor> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventor> Get(Func<Inventor, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Inventor item)
        {
            throw new NotImplementedException();
        }

        public void Update(Inventor item)
        {
            throw new NotImplementedException();
        }
    }
}