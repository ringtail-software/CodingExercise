using System;

namespace NuixTrade.Models
{
	public interface ITradeTransaction
	{
		int TradeId { get; }
		TransactionType TypeOfTransaction { get; }
		DateTime TradeDate { get; }
		int NumShares { get; }
		decimal SharePrice { get; }

		decimal GetTotalPurchasePrice();
	}
}
