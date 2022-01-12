using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Entities.Common
{
    public class CodeGenerator: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Seed { get; set; }
        public int CurrentNumber { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string NumberCategory { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Prefix { get; set; }
        public int CharacterCount { get; set; }
    }
}
