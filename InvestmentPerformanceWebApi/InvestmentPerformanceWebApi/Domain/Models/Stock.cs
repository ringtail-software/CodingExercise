namespace InvestmentPerformanceWebApi.Domain.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
