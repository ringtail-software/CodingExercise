package com.tvd.trading.service

import akka.actor.ActorSystem
import akka.http.scaladsl.model.{ContentTypes, StatusCodes}
import akka.http.scaladsl.server.{MissingQueryParamRejection, Route}
import akka.http.scaladsl.testkit.{RouteTestTimeout, ScalatestRouteTest}
import org.junit.runner.RunWith
import org.scalamock.scalatest.MockFactory
import org.scalatest.matchers.should.Matchers
import org.scalatest.wordspec.AnyWordSpec
import org.scalatestplus.junit.JUnitRunner

import scala.concurrent.duration.DurationInt

@RunWith(classOf[JUnitRunner])
class ServiceRoutesSpec extends AnyWordSpec with Matchers with ScalatestRouteTest with ServiceRoutes with MockFactory {

  final val MaximumRequestDuration: Int = 1

  implicit def default(implicit system: ActorSystem): RouteTestTimeout = RouteTestTimeout(new DurationInt(MaximumRequestDuration).second)

  "The main routing service" should {

    // PING
    "return a pong for GET ping request" in {
      Get("/trading/ping") ~> Route.seal(serviceRoutes) ~> check {
        status shouldEqual StatusCodes.OK
        contentType should === (ContentTypes.`text/plain(UTF-8)`)
        entityAs[String] should === ("""pong""")
        headers shouldEqual List()
      }
    }

    "return a MethodNotAllowed error for PUT ping requests where PUT is not implemented" in {
      Put("/trading/ping") ~> Route.seal(serviceRoutes) ~> check {
        status shouldEqual StatusCodes.MethodNotAllowed
      }
    }

    // LIST INVESTMENTS
    "return successfully for POST list investments request" in {
      Get("/trading/investment?username=johnone") ~> serviceRoutes ~> check {
        status shouldEqual StatusCodes.OK
        contentType shouldEqual ContentTypes.`text/plain(UTF-8)`
        responseAs[String] shouldEqual """{"111":"one","222":"two"}"""
      }
    }

    "return a missing username query parameter rejection when the parameter path is not supplied" in {
      Get("/trading/investment?something=else") ~> serviceRoutes ~> check {
        rejection shouldEqual MissingQueryParamRejection("username")
      }
    }

    // GET INVESTMENT DETAILS
    "return for GET investment details request" in {
      Get("/trading/investment/111") ~> Route.seal(serviceRoutes) ~> check {
        status shouldEqual StatusCodes.OK
        contentType should === (ContentTypes.`application/json`)
        entityAs[String] should === ("""{"investment_id":"111","number_of_shares":123,"cost_basis_per_share":2.09,"current_value":137.76000000000002,"current_price":1.12,"term":"short","total_gain_loss":-119.31}""")
        headers shouldEqual List()
      }
    }

    // OTHER
    "return a not found message for GET with only slash" in {
      Get("/") ~> Route.seal(serviceRoutes) ~> check {
        responseAs[String] shouldEqual "Not found here!"
      }
    }

    "return a not found error message for GET in the path prefix trading with slash" in {
      Get("/trading/") ~> Route.seal(serviceRoutes) ~> check {
        responseAs[String] shouldEqual "Not found here!"
      }
    }

    "return a not found error message for GET in the path prefix trading without slash" in {
      Get("/trading") ~> Route.seal(serviceRoutes) ~> check {
        responseAs[String] shouldEqual "Not found here!"
      }
    }

    "return a not found error message for GET of a non-existing path" in {
      Get("/trading/non_existing") ~> Route.seal(serviceRoutes) ~> check {
        status shouldEqual StatusCodes.NotFound
      }
    }
  }
}
