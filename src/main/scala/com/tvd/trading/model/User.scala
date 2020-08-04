package com.tvd.trading.model

import com.fasterxml.jackson.annotation.{JsonCreator, JsonProperty}

@JsonCreator
case class User(@JsonProperty("id") id: String,
                @JsonProperty("name") name: String,
                @JsonProperty("investment_id") investmentId: String)
