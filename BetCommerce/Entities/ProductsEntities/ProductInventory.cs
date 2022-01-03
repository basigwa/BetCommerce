using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Entities.ProductsEntities
{
    public class ProductInventory: BaseEntity
    {
        public int Id { get; set; }
        public int Quantity  { get; set; }

    }
}
