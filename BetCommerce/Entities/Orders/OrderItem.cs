using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Entities.Orders
{
    public class OrderItem: BaseEntity
    {
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string  OrderNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
