using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuixTrade.Models
{
	public class InvestmentProduct
	{
		// This is just a data bag for each product that is available
		public int Id;
		public string Name;
		public decimal CurrentPrice; // all prices are in USD
		public DateTime CurrentPriceDate; // Identifies the specific time that the price was obtained

		public InvestmentProduct(int id, string name, decimal price, DateTime priceDateTime)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentException("Missing Investment Name");
			if (price <= 0)
				throw new ArgumentOutOfRangeException("Price must be 0 or higher");
			if (priceDateTime.CompareTo(DateTime.Now) > 0)
				throw new ArgumentOutOfRangeException("Transaction date must not be in the future");

			Id = id;
			Name = name;
			CurrentPrice = price;
			CurrentPriceDate = priceDateTime;
		}


	}
}