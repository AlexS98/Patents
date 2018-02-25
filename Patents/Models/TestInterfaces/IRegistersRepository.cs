using System.Collections.Generic;
using Patents.Models.Entities;

namespace Patents.Models.TestInterfaces
{
    public interface IRegistersRepository
    {
        IEnumerable<Register> Registers { get; }
    }
}
