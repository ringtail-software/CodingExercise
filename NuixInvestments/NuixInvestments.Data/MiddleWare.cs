using NuixInvestments.MiddleWare.Data.POCO;
using NuixInvestments.MiddleWare.Data.Repo.Interfaces;
using System.Collections.Generic;

namespace NuixInvestments.Data
{
    public class MiddleWare : IMiddleWare
    {
        protected readonly IUserRepo UserRepo;

        public MiddleWare(IUserRepo userRepo)
        {
            UserRepo = userRepo;
        }

        public IEnumerable<UserInvestment> GetAllInvestmentsForUser(int userId)
        {
            var userInvestments = UserRepo.GetAllInvestmentsByUser(userId);
            return userInvestments;
        }

        public UserInvestment GetSingleInvestmentForUser(int userId, int investmentId)
        {
            var userInvestment = UserRepo.GetSingleInvestmentByUser(userId, investmentId);
            return userInvestment;
        }
    }
}
