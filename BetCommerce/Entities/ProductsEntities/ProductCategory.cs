using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Entities.ProductEntities
{
    public class ProductCategory:BaseEntity
    {
        public int ProductCategoryId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ProductCategoryName { get; set; }
    }
}
