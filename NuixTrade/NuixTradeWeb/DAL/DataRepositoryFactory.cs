using NLog;
using NuixTrade.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NuixTradeWeb.DAL
{
	/// <summary>
	/// Temporary approach to retrieve IDataRepository.
	/// It should be replaced by a full Dependency Injection framework
	/// </summary>
	public static class DataRepositoryFactory
	{
		public static IDataRepository GetDataRepository(Logger nLogger)
		{
			string useSqlRepository = ConfigurationManager.AppSettings["UseSqlDataRepository"];
			if (useSqlRepository.ToLower() == "true" || useSqlRepository.ToLower() == "yes")
				return new SqlDataRepository(nLogger);
			else
				return new DummyDataRepository(nLogger);
		}
	}
}