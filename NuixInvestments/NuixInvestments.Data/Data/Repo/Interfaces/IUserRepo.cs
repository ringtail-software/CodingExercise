using NuixInvestments.MiddleWare.Data.POCO;
using System.Collections.Generic;

namespace NuixInvestments.MiddleWare.Data.Repo.Interfaces
{
    public interface IUserRepo
    {
        UserInvestment GetSingleInvestmentsByUser(int userId, int investmentId);

        IEnumerable<UserInvestment> GetAllInvestmentsByUser(int userId);
    }
}
