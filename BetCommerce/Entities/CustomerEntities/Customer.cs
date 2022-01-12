using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Entities.CustomerEntities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
    }
}
