using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public interface IMeetingsRepository
    {
        IEnumerable<Meeting> Meetings { get; }
    }
}
