using System.Collections.Generic;

namespace Patents.Models.TestInterfaces
{
    public interface IRegistersRepository
    {
        IEnumerable<Register> Registers { get; }
    }
}
