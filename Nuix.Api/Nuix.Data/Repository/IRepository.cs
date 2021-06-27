using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuix.Data.Model;

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