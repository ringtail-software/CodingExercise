using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InvestmentPerformanceWebApi.ApiModels;
using InvestmentPerformanceWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformanceWebApi.Domain
{
    public class InvestmentDal
    {
        private readonly InvestmentDataContext _context;
        private readonly IMapper _mapper;

        public InvestmentDal(InvestmentDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<Investment> QueryUserInvestments(int userId)
        {
            return _context.Investments.Where(i => i.UserId == userId);
        }

        public async Task<List<InvestmentSummary>> GetUserInvestmentSummaries(int userId)
        {
            return await QueryUserInvestments(userId)
                .ProjectTo<InvestmentSummary>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Investment> GetInvestmentData(int userId, int investmentId)
        {
            return await QueryUserInvestments(userId)
                .Where(i => i.InvestmentId == investmentId)
                .FirstOrDefaultAsync();
        }
    }
}
