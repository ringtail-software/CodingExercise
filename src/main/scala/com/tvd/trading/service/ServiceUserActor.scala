package com.tvd.trading.service

import akka.actor.Actor
import com.tvd.trading.Logger
import com.tvd.trading.dao.InvestmentDao
import com.tvd.trading.manager.UserManager

object ServiceUserActor {
  final case class GetListOfInvestments(name: String)
}

class ServiceUserActor extends Actor with Logger {
  import ServiceUserActor._

  override def preStart(): Unit = {
    logger.debug("Starting log user actor...")
  }

  override def preRestart(reason: Throwable, message: Option[Any]): Unit = {
    logger.error(s"User manager actor restarted because of: ${message.getOrElse("unknown error").toString}", reason)
  }

  def getListOfInvestments(name: String): String = {
    logger.debug("Getting the list of investments for user [{}]", name)
    val investmentDao = new InvestmentDao()
    val listOfInvestments = UserManager.getListOfInvestmentsForUser(name, investmentDao)

    mapper.writeValueAsString(listOfInvestments)
  }

  def receive: Receive = {
    case GetListOfInvestments(path) =>
      sender() ! getListOfInvestments(path)
  }
}