package com.tvd.trading.manager

import com.tvd.trading.Logger
import com.tvd.trading.dao.InvestmentDao

object UserManager extends Logger {

  def getListOfInvestmentsForUser(name: String, investmentDao: InvestmentDao): Map[String, String] = {
    logger.debug("Processing the 'get list of investments' request for user [{}]", name)
    val investmentList = investmentDao.getListOfInvestments(name)
    investmentList
  }
}
