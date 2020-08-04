package com.tvd.trading.dao

import com.fasterxml.jackson.databind.ObjectMapper
import com.fasterxml.jackson.module.scala.{DefaultScalaModule, ScalaObjectMapper}
import com.tvd.trading.AlertException
import com.tvd.trading.WebServer.logger
import com.tvd.trading.model.{Investment, User}

import scala.io.Source

class InvestmentDao {

  val mapper = new ObjectMapper() with ScalaObjectMapper
  mapper.registerModule(DefaultScalaModule)

  val investmentJson : String = Source.fromResource("investments.json").mkString
  val userJson : String = Source.fromResource("users.json").mkString

  val listOfInvestments: List[Investment] = mapper.readValue[List[Investment]](investmentJson)
  val listOfUsers: List[User] = mapper.readValue[List[User]](userJson)

  // TABLES
  // =========================================================
  // INVESTMENT                           USER
  // -----------------                    --------------------
  // id                                   id
  // name                                 name
  // number_of_shares                     investment_id
  // cost_basis_per_share
  // stock_id
  // created_at

  def queryGetInvestmentsByUsername(username: String): String =
    s"""
       |SELECT id, name
       |FROM investment
       |WHERE id IN (
       |  SELECT investment_id
       |  FROM user
       |  WHERE name = $username
       |)
       |""".stripMargin

  def queryGetInvestmentDetails(investment_id: String): String =
    s"""
       |SELECT *
       |FROM investment
       |WHERE id = $investment_id
       |""".stripMargin

  def getListOfInvestments(username: String): Map[String, String] = {
    var listOfInvestmentIds: List[String] = List[String]()
    try {
      listOfInvestmentIds = getListOfInvestmentIdsForUser(username)
    } catch {
      case e: Exception =>
        logger.error(s"Couldn't retrieve the list of investments for user [$username]. " +
          s"Details: ${e.getStackTrace.mkString("Array(", ", ", ")")}")
        throw new AlertException(s"Couldn't retrieve the list of investments for user [$username].")
    }

    try {
      listOfInvestments
        .filter(investment => listOfInvestmentIds.contains(investment.id))
        .map(inv => inv.id -> inv.name)
        .toMap
    } catch {
      case e: Exception =>
        logger.error(s"Failed to extract the investments from the list for user [$username]. " +
          s"Details: ${e.getStackTrace.mkString("Array(", ", ", ")")}")
        throw new AlertException(s"Couldn't retrieve the list of investments for user [$username].")
    }
  }

  def getListOfInvestmentIdsForUser(name: String): List[String] = {
    val listOfInvestmentIds: List[User] = listOfUsers.filter(user => user.name == name)
    listOfInvestmentIds.map(u => u.investmentId)
  }

  def getInvestmentDetails(id: String): Option[Investment] = {
    listOfInvestments.find(investment => investment.id == id)
  }
}
