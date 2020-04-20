// To simulate a database connection, data is retrieved from local JSON file SampleData.json

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SampleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Data
{
    public class InvestmentDbContext
    {
        // Returns list of all Client records 
        public IEnumerable<Client> GetAllClients()
        {
            var dataFile = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Data", "SampleData.json"));
            JObject data = JObject.Parse(dataFile);
            return data.SelectToken("Clients").ToObject<List<Client>>();
        }

        // Returns list of all Investment records for Client Id = ClientId
        public IEnumerable<Investment> GetAllInvestments(int ClientId)
        {
            var dataFile = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Data","SampleData.json"));
            JObject data = JObject.Parse(dataFile);
            List<Investment> investments = data.SelectToken("Investments").ToObject<List<Investment>>();
            if (investments == null)
                return null;
            return investments.Where(inv => inv.ClientOwnerId == ClientId) ?? null;
        }

        // Returns Investment details for Investment Id = InvestmentId
        public Investment GetInvestmentDetail(int InvestmentId)
        {
            var dataFile = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Data", "SampleData.json"));
            JObject data = JObject.Parse(dataFile);
            List<Investment> investments = data.SelectToken("Investments").ToObject<List<Investment>>();
            if (investments == null)
                return null;
            return investments.Where(inv => inv.Id == InvestmentId).First() ?? null;
        }

    }
}
