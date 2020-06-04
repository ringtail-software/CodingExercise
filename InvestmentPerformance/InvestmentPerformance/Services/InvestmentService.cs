using InvestmentPerformance.Dtos;
using InvestmentPerformance.Models;
using InvestmentPerformance.Repositories;
using InvestmentPerformance.Resource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformance.Services
{
    public class InvestmentService : IInvestmentService
    {
        private IInvestmentRepository _investmentRepository;
        private ICurrentPriceService _currentPriceService;

        public InvestmentService(IInvestmentRepository investmentRepository, ICurrentPriceService currentPriceService)
        {
            _investmentRepository = investmentRepository;
            _currentPriceService = currentPriceService;
        }
        public async Task<IEnumerable<Investment>> GetInvestmentList(Guid userGuid)
        {
            //map Dto to Investment Model list.
            //  Since it is a simple mapping will just do it in code.
            //  If more complex mapping, automapper nuget package will need to be imported.
            List<Investment> investmentList = new List<Investment>();
            IEnumerable<InvestmentDto> investmentDtoList = await _investmentRepository.GetInvestments(userGuid);
            foreach(InvestmentDto dto  in investmentDtoList)
            {
                investmentList.Add(
                    new Investment()
                    {
                        Name = dto.Name,
                        Id = dto.InvestmentId
                    }
                );
            }
            return investmentList;
        }

        /// <summary>
        /// Handle all the calculations in this service method
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="investmentName"></param>
        /// <returns></returns>
        public async Task<InvestmentDetails> GetInvestmentPerformanceDetails(Guid userGuid, string investmentName)
        {

            InvestmentTransactionDto transactionDto = await _investmentRepository.GetInvestmentDetails(userGuid, investmentName);
            if (transactionDto == null) return null;

            //map some of the transaction details to Investment details model.  
            InvestmentDetails details = new InvestmentDetails()
            {
                Shares = transactionDto.Shares,
                CostBasisPerShare = transactionDto.PurchasePrice
            };
            //get the current price.  This call is to mimick calling a realtime stock ticker api.
            double currentPrice = _currentPriceService.GetCurrentPrice(transactionDto.PurchasePrice);
            details.CurrentPrice = currentPrice;

            //calculate performance data
            details.Term = Calculator.CalculateTerm(transactionDto.PurchaseTimeStamp).ToString();
            details.Profit = Calculator.CalculateProfit(transactionDto.PurchasePrice, transactionDto.Shares, currentPrice);
            details.CurrentValue = Calculator.CalculateCurrentValue(transactionDto.Shares, currentPrice);
            return details;

        }


    }
}
