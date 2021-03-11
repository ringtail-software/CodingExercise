using CodingExercise.DAL.Models;
using System.Collections.Generic;

namespace CodingExercise.DAL
{
    public interface IRepository
    {
        IEnumerable<InvestmentModel> GetUserInvestments(int userId);
        InvestmentModel GetUserInvestmentDetail(int userId, int investmentDetail);
        void PopulateUsers();
    }
}
