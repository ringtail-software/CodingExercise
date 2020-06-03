using InvestmentPerformance.Dtos;
using InvestmentPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace InvestmentPerformance.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        public IEnumerable<InvestmentDto> GetInvestments(Guid userGuid)
        {
            return new List<InvestmentDto>()
            {
                new InvestmentDto() {Name="Nuix Holdings", Id=1, Type=InvestmentType.Stock},
                new InvestmentDto() {Name="Microsoft", Id=2, Type=InvestmentType.Stock}
            };
        }

        public InvestmentTransactionDto GetInvestmentDetails(Guid userGuid, string investmentName)
        {
            return new InvestmentTransactionDto()
            {
                Name = investmentName,
                PurchasedPrice = 20.33,
                PurchasedTimeStamp = DateTime.Now,
                Id = 1,
                InvestmentId = 1,
                Shares = 10
                
            };
        }
    }
}

//Tsbles
//Transaction
//  Id
//  UserGuid
//  InvestmentId
//  PurchasedPrice
//  PurchasedTimeStamp

//Investment
//  Id
//  Name
//  Type
