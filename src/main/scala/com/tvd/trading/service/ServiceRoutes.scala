package com.tvd.trading.service

import akka.actor.{ActorRef, ActorSystem, Props}
import akka.http.scaladsl.model.{HttpResponse, StatusCodes}
import akka.http.scaladsl.server.Directives._
import akka.http.scaladsl.server.{ExceptionHandler, Route}
import akka.http.scaladsl.server.directives.MethodDirectives.get
import akka.http.scaladsl.server.directives.PathDirectives.path
import akka.http.scaladsl.server.directives.RouteDirectives.complete
import akka.pattern.ask
import akka.util.Timeout
import com.fasterxml.jackson.module.scala.DefaultScalaModule
import com.tvd.trading.Constant.Basic.PathPrefix
import com.tvd.trading.Constant.{Http, RoutePath}
import com.tvd.trading.{AlertException, Logger}
import com.tvd.trading.manager.{InvestmentManager, PingManager}
import com.tvd.trading.model.InvestmentDetails
import com.tvd.trading.service.ServiceInvestmentActor.GetInvestmentDetails
import com.tvd.trading.service.ServiceUserActor.GetListOfInvestments
import com.typesafe.config.{Config, ConfigFactory}

import scala.concurrent.Future
import scala.concurrent.duration._

trait ServiceRoutes extends Logger {

  implicit def system: ActorSystem

  val userActor: ActorRef = system.actorOf(Props[ServiceUserActor], name = "ServiceLogLevelActor")
  val investmentActor: ActorRef = system.actorOf(Props[ServiceInvestmentActor], name = "ServiceInvestmentActor")

  val conf: Config = ConfigFactory.load()

  val httpTimeout: Int = conf.getInt(Http.Timeout)
  implicit lazy val timeout: Timeout = Timeout(Duration(httpTimeout, SECONDS))

  def module: DefaultScalaModule.type = DefaultScalaModule

  implicit def myExceptionHandler: ExceptionHandler = ExceptionHandler {
    case x: AlertException =>
      complete(HttpResponse(StatusCodes.BadRequest, entity = s"Error: ${x.getMessage}"))
    case e: Throwable =>
      logger.error(e.getMessage)
      complete(HttpResponse(StatusCodes.BadRequest, entity = e.getMessage))
  }

  lazy val serviceRoutes: Route =
    pathPrefix(PathPrefix) {
      concat(
        path(RoutePath.Ping) {
          get {
            complete {
              PingManager.response()
            }
          }
        },
        path(RoutePath.Investment) {
          concat(
            get {
              parameters("username".as[String]) {
                path: String =>
                  val listOfInvestmentsResponse: Future[String] = (userActor ? GetListOfInvestments(path)).mapTo[String]
                  onSuccess(listOfInvestmentsResponse) { response => complete(response) }
              }
            }
          )
        },
        path(RoutePath.Investment / Segment) { component: String =>
          get {
            withRequestTimeout(100.seconds) {
              val investmentDetails: Future[InvestmentDetails] = (investmentActor ? GetInvestmentDetails(component)).mapTo[InvestmentDetails]
              onSuccess(investmentDetails) { details => complete(InvestmentManager.response(details)) }
            }
          }
        }
      )
    }
}
