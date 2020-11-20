using AutoMapper;
using InvestmentPerformanceApi.Dtos;
using InvestmentPerformanceApi.Models;

namespace InvestmentPerformanceApi.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investments, InvestmentsReadDto>();
            CreateMap<InvestmentDetails, InvestmentDetailsReadDto>();
            CreateMap<InvestmentDetailsCreateDto, InvestmentDetails>();
        }

    }
}
