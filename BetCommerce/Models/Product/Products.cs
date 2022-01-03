using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Models.Product
{
    public class Products
    {
        public int ProductCategoryId { get; set; }
        public string ProductSKU { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public float Price { get; set; }
        public string ProductThumb { get; set; }
        public string ProductImage { get; set; }
    }
}
