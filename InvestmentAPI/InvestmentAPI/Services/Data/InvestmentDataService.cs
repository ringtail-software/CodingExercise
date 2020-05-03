using InvestmentAPI.Contexts;
using InvestmentAPI.Models;
using System.Collections.Generic;
using System.Linq;

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
            var theId = userId;
            var investments = _context.Investments.Where(x => x.UserId == userId).ToList();

            return investments;
        }

        public InvestmentDetail GetInvestmentDetailById(int id)
        {
            var investmentDetails = _context.InvestmentDetails.FirstOrDefault(x => x.InvestmentId == id);

            return investmentDetails;
        }
    }
}
