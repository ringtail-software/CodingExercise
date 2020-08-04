package com.tvd.trading

object Constant {

  object ActorSystem {
    final val Name = "trading_actor_system"
    final val ServiceRegistry = "ServiceRegistryActor"
  }

  object Basic {
    final val PathPrefix = "trading"
  }

  object Http {
    final val Scheme = "http.scheme"
    final val Hostname = "http.hostname"
    final val Port = "http.port"
    final val Timeout = "http.timeout"
  }

  object RoutePath {
    final val Ping = "ping"
    final val Investment = "investment"
    final val Username = "username"
  }
}
