using System;
using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public class IdeasRepository : IGenericRepository<Idea>
    {
        private readonly EFDBContext context = new EFDBContext();
        private IEnumerable<Idea> Ideas;
        public IdeasRepository()
        {
            Ideas = context.Ideas;
        }

        public void Create(Idea item)
        {
            throw new NotImplementedException();
        }

        public Idea FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Idea> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Idea> Get(Func<Idea, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Idea item)
        {
            throw new NotImplementedException();
        }

        public void Update(Idea item)
        {
            throw new NotImplementedException();
        }
    }
}