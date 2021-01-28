using NuixApi.Models;
using NuixApi.DatabaseCalls;
using System.Threading.Tasks;
namespace NuixApi.BusinessLogic
{
    public class NuixBusinessLogic
    {
        private readonly NuixContext _context;

        public NuixBusinessLogic(NuixContext context)
        {
            _context = context;
        }


        public async Task<InvestmentOutput> ReturnInvestmentDetailedView(int id)
        {
            //Call the database routine.
            return await InvestmentDatabaseCalls.GetInvestmentDetails(_context, id);
        }

    }
}
