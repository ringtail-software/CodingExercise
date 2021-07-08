using AutoMapper;
using Nuix.Data.Dto;
using Nuix.Data.Model;

namespace Nuix.Api.AutoMapperProfiles
{
    public class InvestmentAutoMapperProfile : Profile
    {
        public InvestmentAutoMapperProfile()
        {
            CreateMap<Investment, SimpleInvestmentDto>();
            CreateMap<Investment, DetailInvestmentDto>();
        }
    }
}
