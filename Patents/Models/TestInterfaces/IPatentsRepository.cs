using System.Collections.Generic;
using Patents.Models.Entities;

namespace Patents.Models.TestInterfaces
{
    public interface IPatentsRepository
    {
        IEnumerable<Patent> Patents { get; }
    }
}
