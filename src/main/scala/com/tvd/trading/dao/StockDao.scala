package com.tvd.trading.dao

import com.fasterxml.jackson.databind.ObjectMapper
import com.fasterxml.jackson.module.scala.{DefaultScalaModule, ScalaObjectMapper}
import com.tvd.trading.model.Stock

import scala.io.Source

class StockDao {

  val mapper = new ObjectMapper() with ScalaObjectMapper
  mapper.registerModule(DefaultScalaModule)

  val stocksJson : String = Source.fromResource("stocks.json").mkString
  val listOfStocks: List[Stock] = mapper.readValue[List[Stock]](stocksJson)

  // TABLE STOCK
  // -----------------
  // id
  // name
  // current_price
  // updated_at

  def queryGetStockById(id: String): String =
    s"""
       |SELECT id, name, current_price, updated_at
       |FROM stock
       |WHERE id = $id
       |""".stripMargin

  def getStockDetails(stock_id: String): Option[Stock] = {
    listOfStocks.find(s => s.id == stock_id)
  }
}
