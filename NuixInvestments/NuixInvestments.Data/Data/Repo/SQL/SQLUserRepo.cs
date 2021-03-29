using NuixInvestments.MiddleWare.Data.POCO;
using NuixInvestments.MiddleWare.Data.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuixInvestments.MiddleWare.Data.Repo.SQL
{
    public class SQLUserRepo : IUserRepo
    {
        public UserInvestment GetSingleInvestmentsByUser(int userId, int investmentId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserInvestment> GetAllInvestmentsByUser(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
