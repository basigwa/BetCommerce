using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Entities.ProductEntities
{
    public class Product: BaseEntity
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string ProductName { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string ProductDesc { get; set; }
        public float Price { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string ProductThumb { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string ProductImage { get; set; }


    }
}
