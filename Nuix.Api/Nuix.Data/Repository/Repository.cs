using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuix.Data.Model;

namespace Nuix.Data.Repository
{
    public class Repository : IRepository
    {
        public Repository()
        {
            Initialize();
        }

        public async Task<IEnumerable<Investment>> GetUserInvestments(string userName)
        {
            if (Clients.ContainsKey(userName))
                return await Task.FromResult(Clients[userName]);

            return await Task.FromResult(new List<Investment>());
        }

        public async Task<IEnumerable<Investment>> GetUserInvestmentsFiltered(string userName, string investmentName, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (Clients.ContainsKey(userName))
            {
                var investments = Clients[userName]
                    .Where(i => i.Name.Equals(investmentName, comparison));

                return await Task.FromResult(investments.ToList());
            }

            return await Task.FromResult(new List<Investment>());
        }

        private void Initialize()
        {
            // Make our dictionary keys case-insensitive.
            Clients = new Dictionary<string, IEnumerable<Investment>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Mark"] = new List<Investment>()
                {
                    new()
                    {
                        Id = 1,
                        Name = "ABC",
                        NumberOfShares = 1,
                        CostBasisPerShare = 129.21m,
                        CurrentPrice = 131.99m,
                        PurchaseDate = DateTime.Now.AddYears(-1)
                    },
                    new()
                    {
                        Id = 2,
                        Name = "XYZ",
                        NumberOfShares = 3,
                        CostBasisPerShare = 329.21m,
                        CurrentPrice = 431.99m,
                        PurchaseDate = DateTime.Now.AddYears(-2)
                    },
                    new()
                    {
                        Id = 77,
                        Name = "XYZ",
                        NumberOfShares = 30,
                        CostBasisPerShare = 29.21m,
                        CurrentPrice = 131.99m,
                        PurchaseDate = DateTime.Now.AddYears(-20)
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Scuba's Drive Thru",
                        NumberOfShares = 6,
                        CostBasisPerShare = 329.21m,
                        CurrentPrice = 131.99m,
                        PurchaseDate = DateTime.Now.AddYears(-2)
                    },
                },
                ["Suzy"] = new List<Investment>()
                {
                    new()
                    {
                        Id = 4,
                        Name = "ABC",
                        NumberOfShares = 10,
                        CostBasisPerShare = 57.21m,
                        CurrentPrice = 131.99m,
                        PurchaseDate = DateTime.Now.AddYears(-4)
                    },
                    new()
                    {
                        Id = 5,
                        Name = "XYZ",
                        NumberOfShares = 3,
                        CostBasisPerShare = 29.21m,
                        CurrentPrice = 431.99m,
                        PurchaseDate = DateTime.Now.AddYears(-18)
                    },
                }
            };
        }

        private Dictionary<string, IEnumerable<Investment>> Clients;
    }
}