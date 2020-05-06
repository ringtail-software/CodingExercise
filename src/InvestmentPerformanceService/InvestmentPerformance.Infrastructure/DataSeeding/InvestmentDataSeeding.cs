using System;
using System.Collections.Generic;
using InvestmentPerformance.Domain.AggregatesModel;

namespace InvestmentPerformance.Infrastructure.DataSeeding
{
    /// <summary>
    /// This class is in charge of setting up fake investment data for the in-memory database this coding exercise will use
    /// </summary>
    public class InvestmentDataSeeding
    {
        /// <summary>
        /// Gets fake investment data to seed into our dbContext (InvestmentPerformanceContext)
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Investment> GetData()
        {
            var investments = new List<Investment>();

            var oncobiologics = new Investment(1, "Oncobiologics, Inc.", 1, 43, 3768.07m, 3939.79m, 90.25m, 4.768m, 39.87m);
            investments.Add(oncobiologics);

            var globalNetLease = new Investment(2, "Global Net Lease, Inc.", 1, 28, 1874.88m, 1822.85m, 85.65m, 2.412m, 67.48m);
            investments.Add(globalNetLease);

            var ashfordHospitality = new Investment(3, "Ashford Hospitality Trust Inc", 1, 26, 6092.32m, 3607.18m, 97.90m, 3.157m, 64.47m);
            investments.Add(ashfordHospitality);

            var tidewater = new Investment(4, "Tidewater Inc.", 1, 22, 1209.58m, 720.96m, 15.90m, 2.014m, 48.58m);
            investments.Add(tidewater);

            var mellanox = new Investment(5, "Mellanox Technologies, Ltd.", 1, 49, 9923.63m, 4979.40m, 72.69m, 0.184m, 4.14m);
            investments.Add(mellanox);

            var vwrCorporation = new Investment(6, "VWR Corporation", 2, 35, 1179.99m, 577.47m, 77.24m, 4.11m, 92.73m);
            investments.Add(vwrCorporation);

            var hookerFurniture = new Investment(7, "Hooker Furniture Corporation", 2, 49, 8164.57m, 1187.70m, 48.89m, 2.886m, 7.96m);
            investments.Add(hookerFurniture);

            var cardConnect = new Investment(8, "CardConnect Corp.", 2, 46, 3792.87m, 4794.65m, 70.62m, 1.247m, 86.54m);
            investments.Add(cardConnect);

            var kraneShares = new Investment(9, "KraneShares CSI China Internet ETF", 2, 25, 5481.97m, 1365.75m, 2.52m, 0.875m, 15.35m);
            investments.Add(kraneShares);

            var jewettCameron = new Investment(10, "Jewett-Cameron Trading Company", 2, 47, 4499.24m, 2809.80m, 31.24m, 0.214m, 79.32m);
            investments.Add(jewettCameron);

            return investments;
        }
    }
}
