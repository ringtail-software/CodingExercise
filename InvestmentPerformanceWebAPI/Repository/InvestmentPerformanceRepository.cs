using InvestmentPerformance.Data.Context;
using InvestmentPerformance.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentPerformance.WebAPI.Repository
{
    public class InvestmentPerformanceRepository: IInvestmentPerformanceRepository
    {
        InvestmentPerformanceContext _context;

        public InvestmentPerformanceRepository(InvestmentPerformanceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserInvestment> GetAllInvestmentsForUser(int userId)
        {
            try
            {
                var userInvestments = _context.UserInvestments.Include(x => x.Stock).Where(x => x.UserId == userId).ToList();
                return userInvestments;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="investmentId"></param>
        /// <returns></returns>
        public UserInvestment GetInvestmentDetailsById(int userId, int investmentId)
        {
            try
            {
                var userInvestments = _context.UserInvestments
                    .Include(x => x.Stock)
                    .Where(x => x.UserId == userId && x.InvestmentId == investmentId).FirstOrDefault();

                return userInvestments;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
