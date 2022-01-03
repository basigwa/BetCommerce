﻿using BetCommerce.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Models.Orders
{
    public class OrderVM
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public float Total { get; set; }
        public int PaymentMethod { get; set; }
        public int OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
