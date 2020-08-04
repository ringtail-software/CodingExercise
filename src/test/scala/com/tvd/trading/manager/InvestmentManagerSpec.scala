package com.tvd.trading.manager

import com.tvd.trading.dao.{InvestmentDao, StockDao}
import com.tvd.trading.model.{Investment, InvestmentDetails, Stock}
import org.junit.runner.RunWith
import org.scalatest.flatspec.AnyFlatSpec
import org.scalamock.scalatest.MockFactory
import org.scalatest.matchers.should.Matchers
import org.scalatestplus.junit.JUnitRunner

@RunWith(classOf[JUnitRunner])
class InvestmentManagerSpec extends AnyFlatSpec with Matchers with MockFactory {

  "The investment manager" should "retrieve the expected investment details" in {
    val investmentMock = mock[InvestmentDao]
    val stockMock = mock[StockDao]
    val investmentId = "111"
    val stockId = "999"
    val investmentName = "first"
    val stockName = "gold"

    (investmentMock.getInvestmentDetails(_: String))
      .expects("111")
      .returning(Option(
        Investment(
          id = investmentId,
          name = investmentName,
          numberOfShares = 123,
          costBasisPerShare = 1.59,
          stockId = stockId,
          timestamp = 1596485876755L)))

    (stockMock.getStockDetails(_: String))
      .expects("999")
      .returning(Option(
        Stock(id = stockId,
          name = stockName,
          currentPrice = 123,
          timestamp = 1596485876755L)))

    val actualInvestmentDetails = InvestmentManager.getInvestmentDetails(investmentId, investmentMock, stockMock)

    actualInvestmentDetails shouldBe InvestmentDetails(
      investmentId = investmentId,
      numberOfShares = 123,
      costBasisPerShare = 1.59,
      currentValue = 15129.0,
      currentPrice = 123.0,
      term = "short",
      gainLoss = 14933.43)
  }
}
