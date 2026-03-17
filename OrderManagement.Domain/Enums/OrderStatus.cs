using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Enums
{
    public enum OrderStatus
    {
        Created = 1,
        Paid = 2,
        Shipped = 3,
        Cancelled = 4
    }
}
