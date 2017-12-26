using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public interface IPatentsRepository
    {
        IEnumerable<Patent> Patents { get; }
    }
}
