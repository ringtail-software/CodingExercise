using Nuix.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nuix.Data.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Investment>> GetUserInvestments(string userName);

        Task<IEnumerable<Investment>> GetUserInvestmentsFiltered(
            string userName,
            string investmentName,
            StringComparison comparison = StringComparison.OrdinalIgnoreCase);
    }
}