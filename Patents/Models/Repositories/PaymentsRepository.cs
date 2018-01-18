using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patents.Models.Repositories
{
    public class PaymentsRepository
    {
        private readonly EFDBContext context = new EFDBContext();
        public IEnumerable<Payment> Payments
        {
            get
            {
                var payments = context.Payments;                
                return payments;
            }
        }
    }
}