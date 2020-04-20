using Newtonsoft.Json.Linq;
using SampleWebAPI.Data;
using SampleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Services
{
    public class InvestmentServices
    {
        // Fetch all Client records
        public IEnumerable<Client> GetAllClients()
        {
            return new InvestmentDbContext().GetAllClients();
        }

        // Fetch all Investment records for Client Id = CLientId
        public IEnumerable<Investment> GetAllInvestments(int ClientId)
        {                    
            return new InvestmentDbContext().GetAllInvestments(ClientId);
        }

        // Fetch Investment details for Inveestment Id = InvestmentId
        public Investment GetInvestmentDetail(int InvestmentId)
        {
            return new InvestmentDbContext().GetInvestmentDetail(InvestmentId);
        }

        // Fetch Investment detail for Investment Id = InvestmentId and calculate analysis
        public Analysis GetInvestmentAnalysis(int InvestmentId)
        {
            var investment = new InvestmentDbContext().GetInvestmentDetail(InvestmentId);
            if (investment == null)
                return null;
            var currentPrice = GetUpdatedPrice(investment.Stock.Symbol);
            return new Analysis
            {
                CostBasis = investment.PurchasePrice,
                Quantity = investment.Quantity,
                CurrentPrice = currentPrice,
                CurrentValue = currentPrice * investment.Quantity,
                NetGain = (currentPrice - investment.PurchasePrice) * investment.Quantity,
                TermInDays = Convert.ToInt32((DateTime.Today - investment.PurchaseDate).TotalDays),
                TermDesc = (DateTime.Today - investment.PurchaseDate).TotalDays > 365 ? "long" :"short"
            };
        }

        public decimal GetUpdatedPrice(string StockSymbol)
        {
            // This is where the external call would be to retrieve the current stock price.
            // I will simulate by finding the original price and randomly adjusting it.

            var dataFile = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Data", "SampleData.json"));
            JObject data = JObject.Parse(dataFile);
            List<Investment> investments = data.SelectToken("Investments").ToObject<List<Investment>>();

            if (investments == null)
                return 0;

            decimal origPrice = investments
                .Where(inv => inv.Stock.Symbol == StockSymbol)
                .FirstOrDefault()
                .PurchasePrice;

            Random random = new Random();

            return origPrice * random.Next(1, 10) / 5;
        }
    }
}
