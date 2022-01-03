using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Entities.Orders
{
    public class OrderDetail: BaseEntity
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public float Total { get; set; }
        public int PaymentMethod { get; set; }
        public int OrderStatus { get; set; }

    }
}
