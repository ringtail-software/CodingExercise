using NuixInvestments.MiddleWare.Data.POCO;
using System;
using System.Collections.Generic;

namespace NuixInvestments.Data
{
    public interface IMiddleWare
    {
        IEnumerable<UserInvestment> GetAllInvestmentsForUser(int userId);

        UserInvestment GetSingleInvestmentForUser(int userId, int investmentId);
    }
}
