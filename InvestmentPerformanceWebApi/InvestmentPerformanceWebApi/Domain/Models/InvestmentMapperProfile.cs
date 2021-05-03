using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentPerformanceWebApi.ApiModels;

namespace InvestmentPerformanceWebApi.Domain.Models
{
    public class InvestmentMapperProfile : Profile
    {
        public InvestmentMapperProfile()
        {
            CreateMap<Investment, InvestmentSummary>();
            CreateMap<Investment, InvestmentDetail>();

            CreateMap<Stock, InvestmentDetail>()
                .ForMember(d => d.CurrentPrice, c => c.MapFrom(d => d.Price));
        }
    }
}
