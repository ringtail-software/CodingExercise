using InvestmentAPI.Contexts;
using InvestmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentAPI.Services.Data
{
    public class InvestmentDataService : IInvestmentDataService
    {
        private InvestmentContext _context;

        public InvestmentDataService(InvestmentContext context)
        {
            _context = context;
        }

        public List<Investment> GetInvestmentByUserId(int userId)
        {
            List<Investment> investments;
            investments = _context.Investments.Where(x => x.UserId == userId).ToList();

            return investments;
        }

        public InvestmentDetail GetInvestmentDetailById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
