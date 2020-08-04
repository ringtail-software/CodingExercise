package com.tvd.trading

import org.slf4j
import org.slf4j.LoggerFactory

trait Logger {
  val logger: slf4j.Logger = LoggerFactory.getLogger(getClass)
}