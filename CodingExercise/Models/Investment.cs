using Newtonsoft.Json;
using System;

namespace CodingExercise.Models
{
    public class Investment
    {
        [JsonProperty("number_of_shares")]
        public int NumberOfShares { get; set; }
        [JsonProperty("cost_basis")]
        public decimal CostBasis { get; set; }
        public decimal CurrentValue => (NumberOfShares * CurrentPrice);
        [JsonProperty("current_price")]
        public decimal CurrentPrice { get; set; }
        public decimal TotalGainLoss => (NumberOfShares * CurrentPrice) - (NumberOfShares * CostBasis);
        [JsonProperty("purchase_date")]
        public DateTime PurchaseDate { get; set; }
        public string Term => (DateTime.Today - PurchaseDate).TotalDays <= 365 ? "Short Term" : "Long Term";
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

    }

    public class InvestmentDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("number_of_shares")]
        public int NumberOfShares { get; set; }
        [JsonProperty("cost_basis")]
        public decimal CostBasis { get; set; }
        [JsonProperty("current_value")]
        public decimal CurrentValue { get; set; }
        [JsonProperty("current_price")]
        public decimal CurrentPrice { get; set; }
        [JsonProperty("total_gain_loss")]
        public decimal TotalGainLoss { get; set; }
        [JsonProperty("term")]
        public string Term { get; set; }
    }
}
