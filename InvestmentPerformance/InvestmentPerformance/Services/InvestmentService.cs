using InvestmentPerformance.Dtos;
using InvestmentPerformance.Models;
using InvestmentPerformance.Repositories;
using System;
using System.Collections.Generic;

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
        public IEnumerable<Investment> GetInvestmentList(Guid userGuid)
        {
            //map Dto to Investment Model list.
            //  Since it is a simple mapping will just do it in code.
            //  If more complex mapping, automapper nuget package will need to be imported.
            List<Investment> investmentList = new List<Investment>();
            IEnumerable<InvestmentDto> investmentDtoList = _investmentRepository.GetInvestments(userGuid);
            foreach(InvestmentDto dto  in investmentDtoList)
            {
                investmentList.Add(
                    new Investment()
                    {
                        Name = dto.Name,
                        Id = dto.Id
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
        public InvestmentDetails GetInvestmentPerformanceDetails(Guid userGuid, string investmentName)
        {

            InvestmentTransactionDto transactionDto = _investmentRepository.GetInvestmentDetails(userGuid, investmentName);
            //map some of the transaction details to Investment details model.  
            InvestmentDetails details = new InvestmentDetails()
            {
                Shares = transactionDto.Shares,
                CostBasisPerShare = transactionDto.PurchasedPrice
            };
            //get the current price.  This call is to mimick calling a realtime stock ticker api.
            double currentPrice = _currentPriceService.GetCurrentPrice(transactionDto.PurchasedPrice);
            details.CurrentPrice = currentPrice;

            //calculate performance data
            details.Term = CalculateTerm(transactionDto.PurchasedTimeStamp).ToString();
            details.Profit = CalculateProfit(transactionDto.PurchasedPrice, transactionDto.Shares, currentPrice);
            details.CurrentValue = CalculateCurrentValue(transactionDto.Shares, currentPrice);
            return details;

        }

        private TermType CalculateTerm(DateTime purchasedTimeStamp)
        {
            var yearDiff = DateTime.Now.Year - purchasedTimeStamp.Year;
            return yearDiff<=1?TermType.ShortTerm:TermType.LongTerm;
        }

        private double CalculateProfit(double purchasedPrice, int shares, double currentPrice)
        {
            return (currentPrice - purchasedPrice) * shares;
        }

        private double CalculateCurrentValue(int shares, double currentPrice)
        {
            return shares * currentPrice;
        }
    }
}
