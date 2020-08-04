package com.tvd.trading

import akka.actor.ActorSystem
import akka.http.scaladsl.Http
import akka.http.scaladsl.server.Route
import com.tvd.trading.Constant.ActorSystem.Name
import com.tvd.trading.Constant.Basic.PathPrefix
import com.tvd.trading.Constant.Http._
import com.tvd.trading.security.HttpsConnection
import com.tvd.trading.service.ServiceRoutes
import com.typesafe.config.{Config, ConfigFactory}

import scala.concurrent.ExecutionContextExecutor
import scala.io.StdIn

object WebServer extends ServiceRoutes with Logger with HttpsConnection {

  override implicit def system: ActorSystem = ActorSystem(Name)

  def main(args: Array[String]): Unit = {
    logger.info("-- trading --")
    logger.info("Starting the system...")

    implicit val executionContext: ExecutionContextExecutor = system.dispatcher

    lazy val routes: Route = serviceRoutes
    val conf: Config = ConfigFactory.load()

    val scheme = conf.getString(Scheme)
    val hostname = conf.getString(Hostname)
    val port = conf.getInt(Port)

    Http().setDefaultServerHttpContext(https)
    val bindingFuture = Http().bindAndHandle(routes, hostname, port, connectionContext = https)

    logger.info("The system has been started")
    logger.info(s"Server online at $scheme://$hostname:$port/$PathPrefix")
    logger.info("The system is ready")
    StdIn.readLine() // let it run until user presses return
    logger.info("System terminated")
    logger.info("------------------------------------------------")

    bindingFuture
      .flatMap(_.unbind())
      .onComplete(_ => {
        system.terminate()
      })
  }
}
