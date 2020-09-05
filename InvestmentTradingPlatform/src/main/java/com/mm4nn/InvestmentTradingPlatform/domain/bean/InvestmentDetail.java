package com.mm4nn.InvestmentTradingPlatform.domain.bean;

import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

import java.math.BigDecimal;
import java.time.LocalDateTime;

/**
 *  POJO used for encapsulation of investment data
 */
@Setter
@Getter
@EqualsAndHashCode
@ToString
@NoArgsConstructor
public class InvestmentDetail {

    private Stock stock;

    private Integer numberOfShares;
    private BigDecimal pricePerShare;

    private LocalDateTime purchaseDate;

    private BigDecimal costBasisPerShare;
    private BigDecimal currentPrice;
    private BigDecimal initialValue;
    private BigDecimal currentValue;
    private InvestmentTerm term;
    private BigDecimal totalLossOrGain;

    public InvestmentDetailRepresentation toInvestmentDetailRepresentation() {
        return new InvestmentDetailRepresentation(numberOfShares, costBasisPerShare,
                currentPrice, currentValue, term, totalLossOrGain);
    }

}
