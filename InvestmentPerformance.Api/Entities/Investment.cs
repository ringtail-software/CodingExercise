
namespace InvestmentPerformance.Api.Entities
{
    public class Investment : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
