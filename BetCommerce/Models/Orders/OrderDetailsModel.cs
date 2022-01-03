using BetCommerce.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Models.Orders
{
    public class OrderDetailsModel
    {
        public string UserId { get; set; }
        public decimal Total { get; set; }
        public int PaymentMethod { get; set; }
        public int OrderStatus { get; set; }
        public List<OrderItemsModels> OrderItems { get; set; }
    }
}
