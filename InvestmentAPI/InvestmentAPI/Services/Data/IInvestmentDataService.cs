using InvestmentAPI.Models;
using System.Collections.Generic;

namespace InvestmentAPI.Services.Data
{
    public interface IInvestmentDataService
    {
        List<Investment> GetInvestmentByUserId(int userId);
        InvestmentDetail GetInvestmentDetailById(int id);
    }
}
