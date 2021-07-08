using Nuix.Data.Model;
using System;
using System.Collections.Generic;

namespace Nuix.Data.Repository.MoqData
{
    public class Data : IData
    {
        public Data()
        {
            Initialize();
        }

        public Dictionary<string, IEnumerable<Investment>> ClientFactory()
        {
            return _clients;
        }

        private void Initialize()
        {
            // Case-insensitive.
            _clients = new Dictionary<string, IEnumerable<Investment>>(StringComparer.OrdinalIgnoreCase)
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

        private Dictionary<string, IEnumerable<Investment>> _clients;
    }
}
