package com.tvd.trading.model

import com.fasterxml.jackson.annotation.{JsonCreator, JsonProperty}

@JsonCreator
case class Investment(@JsonProperty("id") id: String,
                      @JsonProperty("name") name: String,
                      @JsonProperty("number_of_shares") numberOfShares: Long,
                      @JsonProperty("cost_basis_per_share") costBasisPerShare: Double,
                      @JsonProperty("stock_id") stockId: String,
                      @JsonProperty("created_at") timestamp: Long)

@JsonCreator
case class InvestmentDetails(@JsonProperty("investment_id") investmentId: String,
                             @JsonProperty("number_of_shares") numberOfShares: Long,
                             @JsonProperty("cost_basis_per_share") costBasisPerShare: Double,
                             @JsonProperty("current_value") currentValue: Double,
                             @JsonProperty("current_price") currentPrice: Double,
                             @JsonProperty("term") term: String,
                             @JsonProperty("total_gain_loss") gainLoss: Double)
