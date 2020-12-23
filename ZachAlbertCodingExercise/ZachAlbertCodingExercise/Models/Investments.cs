using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZachAlbertCodingExercise.Models
{
    public class Investments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int StockId { get; set; }

        [Required]
        public int PurchaseAmount { get; set; }

        [Required]
        public int PurchasePrice { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }
    }
}