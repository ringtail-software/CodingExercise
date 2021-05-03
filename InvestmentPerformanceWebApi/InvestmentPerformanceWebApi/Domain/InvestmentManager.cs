using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentPerformanceWebApi.ApiModels;
using InvestmentPerformanceWebApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPerformanceWebApi.Domain
{
    public class InvestmentManager
    {
        private readonly InvestmentDal _dal;
        private readonly StockDal _stockDal;
        private readonly IMapper _mapper;

        public InvestmentManager(InvestmentDal dal, StockDal stockDal, IMapper mapper)
        {
            _dal = dal;
            _stockDal = stockDal;
            _mapper = mapper;
        }

        public async Task<InvestmentDetail> GetInvestmentDetail(int userId, int investmentId)
        {
            var investment = await _dal.GetInvestmentData(userId, investmentId);
            if (investment == null)
                return null;

            var stock = await _stockDal.GetStockPricing(investment.Symbol);
            var result = CreateInvestmentDetail(investment, stock);

            return result;
        }

        protected InvestmentDetail CreateInvestmentDetail(Investment investment, Stock stock)
        {
            var result = _mapper.Map<InvestmentDetail>(investment);
            _mapper.Map(stock, result);

            result.CurrentValue = result.CurrentPrice * result.Quantity;
            result.TotalGain = result.CurrentValue - (result.CostBasis * result.Quantity);
            result.Term = investment.PurchaseTimestamp < DateTime.UtcNow.AddYears(-1) ? TermTypes.Long : TermTypes.Short;

            return result;
        }
    }
}
