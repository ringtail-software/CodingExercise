package com.mm4nn.InvestmentTradingPlatform.domain.bean;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.math.BigDecimal;

/**
 *  DTO used for transfer of investment data in API's
 */
@Data
@AllArgsConstructor
@NoArgsConstructor
public class InvestmentDetailRepresentation {
    private int numberOfShares;
    private BigDecimal costBasisPerShare;
    private BigDecimal currentPrice;
    private BigDecimal currentValue;
    private InvestmentTerm term;
    private BigDecimal totalLossOrGain;
}
