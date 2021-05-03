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
    public class StockDal
    {
        private readonly InvestmentDataContext _context;
        private readonly IMapper _mapper;

        public StockDal(InvestmentDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Stock> GetStockPricing(string symbol)
        {
            return await _context.Stocks
                .Where(s => string.Equals(s.Symbol, symbol))
                .FirstOrDefaultAsync();
        }
    }
}
