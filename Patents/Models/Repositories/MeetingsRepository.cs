using System.Collections.Generic;

namespace Patents.Models.Repositories
{
    public class MeetingsRepository : IMeetingsRepository
    {
        private EFDBContext context = new EFDBContext();
        public IEnumerable<Meeting> Meetings
        {
            get
            {
                var meetings = context.Meetings;
                var state = new StatesRepository().States;
                var inventors = new InventorsRepository().Inventors;
                var registers = new RegistersRepository().Registers;
                foreach (var i in meetings)
                {
                    foreach (var j in state)
                        if (i.StateId == j.StateId)
                        {
                            i.State = j;
                            break;
                        }
                    foreach (var k in inventors)
                        if (i.InventorId == k.InventorId)
                        {
                            i.Inventor = k;
                            break;
                        }
                    foreach (var r in registers)
                        if (i.RegisterId == r.RegisterId)
                        {
                            i.Register = r;
                            break;
                        }
                }
                return meetings;
            }
        }
    }
}