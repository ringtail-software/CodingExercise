using Nuix.Data.Model;
using Nuix.Data.Repository.MoqData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nuix.Data.Repository
{
    public class Repository : IRepository
    {
        public Repository(IData data)
        {
            _clients = data.ClientFactory();
        }

        public async Task<IEnumerable<Investment>> GetUserInvestments(string userName)
        {
            if (_clients.ContainsKey(userName))
                return await Task.FromResult(_clients[userName]);

            return await Task.FromResult(new List<Investment>());
        }

        public async Task<IEnumerable<Investment>> GetUserInvestmentsFiltered(string userName, string investmentName, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (_clients.ContainsKey(userName))
            {
                var investments = _clients[userName]
                    .Where(i => i.Name.Equals(investmentName, comparison));

                return await Task.FromResult(investments.ToList());
            }

            return await Task.FromResult(new List<Investment>());
        }

        private readonly Dictionary<string, IEnumerable<Investment>> _clients;
    }
}