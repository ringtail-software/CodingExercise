using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZachAlbertCodingExercise.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [Required]
        public string StockName { get; set; }

        [Required]
        public int CurrentPrice { get; set; }
    }
}