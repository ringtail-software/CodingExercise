using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZachAlbertCodingExercise.Models
{
    public class UserInvestment
    {
        public int StockId { get; set; }
        public int InvestmentId { get; set; }
        public string StockName { get; set; }
        public int PurchaseAmount { get; set; }
        public int PurchasePrice { get; set; }
        public int CurrentStockPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}