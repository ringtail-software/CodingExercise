using Investment.API.Entities;
using Investment.API.Models;
using System;
using System.Collections.Generic;

namespace Investment.API.Services
{
    public interface IInvestmentRepository
    {
        #region Users
        
        IEnumerable<User> GetUsers();
        User GetUser(Guid userName);
        
        #endregion Users



        #region Security
        
        IEnumerable<Entities.Security> GetSecurities();

        #endregion Security



        #region Investments

        IEnumerable<Entities.Investment> GetInvestments();
        Entities.Investment GetInvestment(long investmentId);

        #endregion Investments
    }
}
