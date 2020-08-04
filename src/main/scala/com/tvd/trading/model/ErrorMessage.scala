package com.tvd.trading.model

import com.fasterxml.jackson.annotation.{JsonCreator, JsonProperty}

@JsonCreator
case class ErrorMessage(@JsonProperty("id") id: String,
                        @JsonProperty("name") name: String,
                        @JsonProperty("description") currentPrice: String)
