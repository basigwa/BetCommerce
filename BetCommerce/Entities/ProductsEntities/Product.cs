using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Entities.ProductEntities
{
    public class Product: BaseEntity
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductSKU { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public float Price { get; set; }
        public string ProductThumb { get; set; }
        public string ProductImage { get; set; }


    }
}
