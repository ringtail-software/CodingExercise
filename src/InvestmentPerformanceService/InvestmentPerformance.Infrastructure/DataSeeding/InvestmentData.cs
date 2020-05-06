using System;
using System.Collections.Generic;
using InvestmentPerformance.Domain.AggregatesModel;

namespace InvestmentPerformance.Infrastructure.DataSeeding
{
    public class InvestmentData
    {
        public static IEnumerable<Investment> GetInvestmentData()
        {
            var investments = new List<Investment>();

            var oncobiologics = new Investment(1, "Oncobiologics, Inc.", DateTime.Parse("9/24/2019"), 1);
            investments.Add(oncobiologics);

            var globalNetLease = new Investment(1, "Global Net Lease, Inc.", DateTime.Parse("7/17/2019"), 1);
            investments.Add(globalNetLease);

            var ashfordHospitality = new Investment(1, "Ashford Hospitality Trust Inc", DateTime.Parse("1/5/2020"), 1);
            investments.Add(ashfordHospitality);

            var tidewater = new Investment(1, "Tidewater Inc.", DateTime.Parse("10/17/2019"), 1);
            investments.Add(tidewater);

            var mellanox = new Investment(1, "Mellanox Technologies, Ltd.", DateTime.Parse("8/3/2019"), 1);
            investments.Add(mellanox);

            var vwrCorporation = new Investment(1, "VWR Corporation", DateTime.Parse("10/31/2019"), 2);
            investments.Add(vwrCorporation);

            var hookerFurniture = new Investment(1, "Hooker Furniture Corporation", DateTime.Parse("8/8/2019"), 2);
            investments.Add(hookerFurniture);

            var cardConnect = new Investment(1, "CardConnect Corp.", DateTime.Parse("8/19/2019"), 2);
            investments.Add(cardConnect);

            var kraneShares = new Investment(1, "KraneShares CSI China Internet ETF", DateTime.Parse("6/23/2019"), 2);
            investments.Add(kraneShares);

            var jewettCameron = new Investment(1, "Jewett-Cameron Trading Company", DateTime.Parse("7/14/2019"), 2);
            investments.Add(jewettCameron);

            return investments;
        }
    }
}