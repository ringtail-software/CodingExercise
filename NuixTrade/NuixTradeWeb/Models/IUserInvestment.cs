namespace NuixTrade.Models
{
	interface IUserInvestment
	{
		InvestmentProduct GetInvestmentProduct();
		TradeTransaction GetPurchaseTransaction();
		// TradeTransaction GetSellTransaction(); // possible future enhancement
		decimal GetCostPerBasisShare();
		decimal GetTotalGainLoss();
		decimal GetCurrentValue();
		InvestmentTerm GetTerm();
	}
}
