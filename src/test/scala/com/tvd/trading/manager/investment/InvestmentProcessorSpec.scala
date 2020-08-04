package com.tvd.trading.manager.investment

import org.junit.runner.RunWith
import org.scalamock.scalatest.MockFactory
import org.scalatest.matchers.should.Matchers
import org.scalatest.wordspec.AnyWordSpec
import org.scalatestplus.junit.JUnitRunner

@RunWith(classOf[JUnitRunner])
class InvestmentProcessorSpec  extends AnyWordSpec with Matchers with MockFactory {

  "The investment processor computes correctly the current investment value" in {
    val expectedValue = 499356
    val actualValue = InvestmentProcessor.getCurrentValue(2134, 234)
    assert(actualValue == expectedValue)
  }

  "The investment processor selects the short term period when the comparing dates are the same" in {
    val exactlyOneYearAgo = System.currentTimeMillis() - (InvestmentProcessor.OneYear / 2)

    val actualValue = InvestmentProcessor.getTermPeriod(exactlyOneYearAgo)
    assert(actualValue == "short")
  }

  "The investment processor selects the short term period" in {
    val lessThanAYear = System.currentTimeMillis()
    val actualValue = InvestmentProcessor.getTermPeriod(lessThanAYear)
    assert(actualValue == "short")
  }

  "The investment processor selects the long term period" in {
    val moreThanAYear = System.currentTimeMillis() - (2 * InvestmentProcessor.OneYear)
    val actualValue = InvestmentProcessor.getTermPeriod(moreThanAYear)
    assert(actualValue == "long")
  }

  "The gain loss is zero when the current cost and the price are equal" in {
    val actualGainLoss = InvestmentProcessor.getGainLoss(numberOfShares = 10000, costBasisPeShare = 9.99999, currentPrice = 9.99999)
    assert(actualGainLoss == 0.0)
  }

  "The gain loss is correct for the happy path" in {
    val actualGainLoss = InvestmentProcessor.getGainLoss(numberOfShares = 99, costBasisPeShare = 1.999, currentPrice = 2.119)
    assert(actualGainLoss == 11.88)
  }

  "The gain loss is negative when the current cost is smaller than the price" in {
    val actualGainLoss = InvestmentProcessor.getGainLoss(numberOfShares = 100, costBasisPeShare = 5.0, currentPrice = 4.0)
    assert(actualGainLoss == -100.0)
  }

}
