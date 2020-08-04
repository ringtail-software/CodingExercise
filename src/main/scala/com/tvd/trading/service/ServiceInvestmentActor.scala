package com.tvd.trading.service

import akka.actor.Actor
import com.tvd.trading.Logger
import com.tvd.trading.dao.{InvestmentDao, StockDao}
import com.tvd.trading.manager.InvestmentManager
import com.tvd.trading.model.InvestmentDetails

object ServiceInvestmentActor {
  final case class GetInvestmentDetails(id: String)
}

class ServiceInvestmentActor extends Actor with Logger {
  import ServiceInvestmentActor._

  override def preStart(): Unit = {
    logger.debug("Starting investment manager actor...")
  }

  override def preRestart(reason: Throwable, message: Option[Any]): Unit = {
    logger.error(s"Investment actor restarted because of: ${message.getOrElse("unknown error").toString}", reason)
  }

  def getInvestmentDetails(id: String): InvestmentDetails = {
    logger.debug("Request the details of the investment with id [{}]", id)
    val investmentDao = new InvestmentDao()
    val stockDao = new StockDao()
    InvestmentManager.getInvestmentDetails(id, investmentDao, stockDao)
  }

  def receive: Receive = {
    case GetInvestmentDetails(component) =>
      sender() ! getInvestmentDetails(component)
  }
}