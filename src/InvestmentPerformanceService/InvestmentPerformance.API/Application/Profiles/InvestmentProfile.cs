using AutoMapper;
using InvestmentPerformance.API.Application.Models;
using InvestmentPerformance.Domain.AggregatesModel;

namespace InvestmentPerformance.API.Application.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, UserInvestment>();
            CreateMap<Investment, InvestmentDetails>();
        }
    }
}
