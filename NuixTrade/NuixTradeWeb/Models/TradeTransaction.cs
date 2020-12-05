using NLog;
using System;

namespace NuixTrade.Models
{
	public class TradeTransaction : ITradeTransaction
	{
		private int _tradeId;
		public int TradeId { get; }

		private TransactionType _transactionType;
		public TransactionType TypeOfTransaction { get { return _transactionType; } }

		private DateTime _tradeDate;
		public DateTime TradeDate { get { return _tradeDate; } }

		private int _numShares;
		public int NumShares { get { return _numShares; } }

		private decimal _sharePrice;
		public decimal SharePrice { get; }

		private Logger _nLogger;

		public TradeTransaction(Logger nLogger, int tradeId, TransactionType transactionType, DateTime tradeDate, int numShares, decimal sharePrice)
		{
			if (tradeId <= 0)
				throw new ArgumentException("trade ID must be a positive value");
			if (numShares <= 0)
				throw new ArgumentException("Number of transaction shares must be a positive value");

			_nLogger = nLogger;
			_tradeId = tradeId;
			_transactionType = transactionType;
			_tradeDate = tradeDate;
			_numShares = numShares;
			_sharePrice = sharePrice;
		}

		public decimal GetTotalPurchasePrice()
		{
			decimal totalPurchasePrice = _numShares *_sharePrice;
			return totalPurchasePrice;
		}
	}
}