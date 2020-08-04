package com.tvd.trading.model

import com.fasterxml.jackson.annotation.{JsonCreator, JsonProperty}

@JsonCreator
case class Stock(@JsonProperty("id") id: String,
                 @JsonProperty("name") name: String,
                 @JsonProperty("current_price") currentPrice: Double,
                 @JsonProperty("timestamp") timestamp: Long)
