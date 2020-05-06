using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentPerformance.API.Application.Models;
using InvestmentPerformance.API.Application.Services.Interfaces;
using InvestmentPerformance.Domain.AggregatesModel;
using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformance.Application.API.Services
{
    /// <summary>
    /// Handles user queries for investments
    /// </summary>
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentReadOnlyRepository _investmentReadOnlyRepository;
        private readonly ILogger<InvestmentService> _logger;
        private readonly IMapper _mapper;

        public InvestmentService(IInvestmentReadOnlyRepository investmentReadOnlyRepository, ILogger<InvestmentService> logger,
                                 IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _investmentReadOnlyRepository = investmentReadOnlyRepository;
        }

        /// <summary>
        /// Get all investments (not for users but for my/your use)
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Investment>> GetAllInvestmentsAsync()
        {
            var investments = Enumerable.Empty<Investment>();

            try
            {
                _logger.LogInformation("Retrieving all Investments..");
                investments = await _investmentReadOnlyRepository.GetAllInvestmentsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an unexpected error retrieving all investments", ex);
            }

            return investments;
        }

        /// <summary>
        /// Get user investments
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserInvestment>> GetUserInvestmentsAsync(int userId)
        {
            var userInvestments = Enumerable.Empty<UserInvestment>();

            try
            {
                _logger.LogInformation($"Retrieving Investments for user with Id '{userId}'");
                var investments = await _investmentReadOnlyRepository.GetUserInvestmentsAsync(userId);

                // mapping Investment list to UserInvestment list view model - only giving back the user what they want to see
                userInvestments = _mapper.Map<IEnumerable<UserInvestment>>(investments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an unexpected error retrieving investment for user with id '{userId}'", ex);
            }

            return userInvestments;
        }

        /// <summary>
        /// Get investment details
        /// </summary>
        /// <param name="investmentId"></param>
        /// <returns></returns>
        public async Task<InvestmentDetails> GetInvestmentDetailsAsync(int investmentId)
        {
            InvestmentDetails investmentDetails = null;

            try
            {
                _logger.LogInformation($"Retrieving Investment Details for Investment with Id '{investmentId}'");
                var investment = await _investmentReadOnlyRepository.GetInvestmentAsync(investmentId);

                // mapping Investment entity to InvestmentDetails view model - only giving back the user what they want to see
                investmentDetails = _mapper.Map<InvestmentDetails>(investment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an unexpected error retrieving investment details for investment with id '{investmentId}'", ex);
            }

            return investmentDetails;
        }
    }
}
