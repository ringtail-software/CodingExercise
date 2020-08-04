package com.tvd.trading.manager

import akka.http.scaladsl.model.{ContentTypes, HttpEntity}
import com.fasterxml.jackson.databind.ObjectMapper
import com.fasterxml.jackson.module.scala.{DefaultScalaModule, ScalaObjectMapper}
import com.tvd.trading.{AlertException, Logger}
import com.tvd.trading.dao.{InvestmentDao, StockDao}
import com.tvd.trading.manager.investment.InvestmentProcessor
import com.tvd.trading.model.{Investment, InvestmentDetails, Stock}

object InvestmentManager extends Logger {

  val mapper = new ObjectMapper() with ScalaObjectMapper
  mapper.registerModule(DefaultScalaModule)

  def getInvestmentDetails(id: String, investmentDao: InvestmentDao, stockDao: StockDao): InvestmentDetails = {

    val investment: Option[Investment] = investmentDao.getInvestmentDetails(id)

    investment match {
      case Some(inv) =>
        val stock: Option[Stock] = stockDao.getStockDetails(inv.stockId)

        stock match {
          case Some(s) =>
            val investmentId = inv.id
            val costBasisPeShare = inv.costBasisPerShare
            val currentValue = InvestmentProcessor.getCurrentValue(inv.numberOfShares, s.currentPrice)
            val term = InvestmentProcessor.getTermPeriod(inv.timestamp)
            val gainLoss = InvestmentProcessor.getGainLoss(inv.numberOfShares, costBasisPeShare, s.currentPrice)

            InvestmentDetails(investmentId, inv.numberOfShares, costBasisPeShare, currentValue, s.currentPrice, term, gainLoss)
          case None =>
            throw new AlertException(s"The stock with id [${inv.stockId}] was not found. " +
              s"The information about stock was required for the investment with id [$id]")
        }
      case None =>
        throw new AlertException(s"The investment with id [$id] was not found")
    }
  }

  def response(investmentDetails: InvestmentDetails): HttpEntity.Strict = {
    HttpEntity(ContentTypes.`application/json`, mapper.writeValueAsString(investmentDetails))
  }
}
