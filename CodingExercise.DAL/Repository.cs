using CodingExercise.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.DAL
{
    public class Repository : IRepository
    {
        private IEnumerable<UserModel> _users;
        public Repository()
        {
        }
        public InvestmentModel GetUserInvestmentDetail(int userId, int investmentDetail)
        {
            return GetUserInvestments(userId).Single(i => i.Id == investmentDetail);
        }

        public IEnumerable<InvestmentModel> GetUserInvestments(int userId)
        {
            return _users.Single(u => u.Id == userId).Investments;
        }

        public void PopulateUsers()
        {
            var data = System.IO.File.ReadAllText("./data.json");
            _users = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<UserModel>>(data);
        }
    }
}
