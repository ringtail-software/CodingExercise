using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investment.API.Entities
{
    public class Security
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public string Symbol { get; set; }

        [Required]
        [Column(TypeName = "decimal(29,9)")]
        public decimal CurrentPrice { get; set; }
    }
}
