using AutoMapper;
using Investment.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investment.API.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Entities.Security, Models.SecurityModel>();

            CreateMap<Entities.Investment, Models.UserInvestmentModel>()
                .ForMember(
                    dest => dest.InvestmentName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.InvestmentId,
                    opt => opt.MapFrom(src => src.Id));

            CreateMap<Entities.Investment, Models.UserInvestmentDetailsModel>()
                .ForMember(
                    dest => dest.Shares,
                    opt => opt.MapFrom(src => src.Shares))
                .ForMember(
                    dest => dest.CostBasis,
                    opt => opt.MapFrom(src => src.PurchasePrice))
                .ForMember(
                    dest => dest.CurrentValue,
                    opt => opt.MapFrom(src => src.Security.CurrentPrice * src.Shares))
                .ForMember(
                    dest => dest.CurrentPrice,
                    opt => opt.MapFrom(src => src.Security.CurrentPrice))
                .ForMember(
                    dest => dest.Term,
                    opt => opt.MapFrom(src => src.PurchaseDate.GetTerm()))
                .ForMember(
                    dest => dest.TotalGainLoss,
                    opt => opt.MapFrom(src => (src.Security.CurrentPrice - src.PurchasePrice) * src.Shares));

            CreateMap<Entities.User, Models.UserModel>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.UserName,
                    opt => opt.MapFrom(src => src.UserName));

            CreateMap<Entities.Investment, Models.InvestmentModel>()
                .ForMember(
                    dest => dest.InvestmentId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.InvestmentName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.PurchaseDate,
                    opt => opt.MapFrom(src => src.PurchaseDate))
                .ForMember(
                    dest => dest.PurchasePrice,
                    opt => opt.MapFrom(src => src.PurchasePrice))
                .ForMember(
                    dest => dest.Shares,
                    opt => opt.MapFrom(src => src.Shares))
                .ForMember(
                    dest => dest.SecuritySymbol,
                    opt => opt.MapFrom(src => src.Security.Symbol));


        }
    }
}
