using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patents.Models.Repositories
{
    public class PaymentsRepository
    {
        private EFDBContext context = new EFDBContext();
        public IEnumerable<Payment> Payments
        {
            get
            {
                var payments = context.Payments;
                var state = new StatesRepository().States;
                var inventors = new InventorsRepository().Inventors;
                var registers = new RegistersRepository().Registers;
                foreach (var i in payments)
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
                return payments;
            }
        }
    }
}