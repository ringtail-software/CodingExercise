using CodingExercise.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.Data
{
    public class CodingExerciseDataAccess
    {
        //Here is the Data Access Layer.  Normally this would be a database, or some other persistent data. For this test purpose, I used just a simple Json file.
        //This would also have a user id argument, but in this sample there is only one user.
        public static List<InvestmentDTO> GetUserInvestments()
        {
            string json = System.IO.File.ReadAllText("Data/data.json");
            var investments = JsonConvert.DeserializeObject<List<Investment>>(json);
            return investments.Select(investment => new InvestmentDTO
            {
                Id = investment.Id,
                Name = investment.Name,
            }

            ).ToList();
        }

        //I map the data to a data transfer object since the instructions listed specific fields that should be returned.  I kept it explicit to show my though process, but would most likely use a mapper in the actual application
        public static InvestmentDTO GetInvestmentDetail(int id)
        {
            string json = System.IO.File.ReadAllText("Data/data.json");
            var investments = JsonConvert.DeserializeObject<List<Investment>>(json);
            var userInvestment = investments.Where(x => x.Id == id).Select(investment => new InvestmentDTO
            {
                Id = investment.Id,
                Name = investment.Name,
                NumberOfShares = investment.NumberOfShares,
                CostBasis = investment.CostBasis,
                CurrentPrice = investment.CurrentPrice,
                CurrentValue = investment.CurrentValue,
                Term = investment.Term,
                TotalGainLoss = investment.TotalGainLoss
            }).FirstOrDefault();

            return userInvestment;
        }
    }
}
