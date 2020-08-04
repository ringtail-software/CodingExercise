package com.tvd.trading.manager.investment

object InvestmentProcessor {

  val OneYear = 31556952000L
  val ShortTermInvestment = "short"
  val LongTermInvestment = "long"

  def getCurrentValue(numberOfShares: Long, currentPrice: Double): Double = {
    numberOfShares * currentPrice
  }

  def getTermPeriod(investmentTimestamp: Long): String = {
    val currentTimestamp = System.currentTimeMillis()

    if(currentTimestamp - investmentTimestamp <= OneYear) {
      ShortTermInvestment
    } else {
      LongTermInvestment
    }
  }

  def getGainLoss(numberOfShares: Long, costBasisPeShare: Double, currentPrice: Double): Double = {
    BigDecimal((currentPrice - costBasisPeShare) * numberOfShares)
      .setScale(6, BigDecimal.RoundingMode.HALF_UP)
      .toDouble
  }
}
