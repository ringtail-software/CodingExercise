using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investment.API.Entities

{
    public class Investment
    {
        [Key]       
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(29,9)")]
        public decimal PurchasePrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(29,9)")]
        public decimal Shares { get; set; }

        public Security Security { get; set; }
    }
}
