using System.Collections.Generic;
using Patents.Models.Entities;

namespace Patents.Models.TestInterfaces
{
    public interface IMeetingsRepository
    {
        IEnumerable<Meeting> Meetings { get; }
    }
}
