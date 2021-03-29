using Microsoft.Extensions.Logging;
using NuixInvestments.MiddleWare.Data.POCO;
using NuixInvestments.MiddleWare.Data.Repo.Interfaces;
using System;
using System.Collections.Generic;

namespace NuixInvestments.Data
{
    public class MiddleWare : IMiddleWare
    {
        protected readonly ILogger Logger;
        protected readonly IUserRepo UserRepo;

        public MiddleWare(ILogger<MiddleWare> logger, IUserRepo userRepo)
        {
            Logger = logger;
            UserRepo = userRepo;
        }

        public IEnumerable<UserInvestment> GetAllInvestmentsForUser(int userId)
        {
            IEnumerable<UserInvestment> userInvestments = null;
            Logger.LogDebug($"MiddleWare.GetAllInvestmentsForUser entered.  UserId: {userId}");

            try
            {
                userInvestments = UserRepo.GetAllInvestmentsByUser(userId);
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
            }

            return userInvestments;
        }

        public UserInvestment GetSingleInvestmentForUser(int userId, int investmentId)
        {
            UserInvestment userInvestment = null;
            Logger.LogDebug($"MiddleWare.GetSingleInvestmentForUser entered.  UserId: {userId}, InvestmentId: {investmentId}");

            try
            {
                userInvestment = UserRepo.GetSingleInvestmentByUser(userId, investmentId);
                return userInvestment;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
            }

            return userInvestment;
        }
    }
}
