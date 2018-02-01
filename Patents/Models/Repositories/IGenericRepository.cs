using System;
using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        void Create(Entity item);
        Entity FindById(int id);
        IEnumerable<Entity> Get();
        IEnumerable<Entity> Get(Func<Entity, bool> predicate);
        void Remove(Entity item);
        void Update(Entity item);
    }
}
