using NuixTrade.Models;
using System.Collections.Generic;

namespace NuixTrade.DAL
{
	public interface IDataRepository
	{
		IEnumerable<InvestmentProduct> GetProductLine();
		IEnumerable<UserInvestment> GetAllUserInvestments(int userId);
	}
}
