using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Entities.Orders
{
    public class OrderDetail: BaseEntity
    {
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string OrderNumber { get; set; }
        public float Total { get; set; }
        public int PaymentMethod { get; set; }
        public int OrderStatus { get; set; }

    }
}
