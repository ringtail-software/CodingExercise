package com.mm4nn.InvestmentTradingPlatform.domain.bean;

import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToOne;
import javax.persistence.Table;
import java.math.BigDecimal;
import java.time.LocalDateTime;

/**
 *  POJO used for encapsulation of investments and entity handling in JPA
 */
@Setter
@Getter
@EqualsAndHashCode
@ToString
@NoArgsConstructor
@Entity
@Table(name = "T_INVESTMENT")
public class Investment {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @EqualsAndHashCode.Exclude
    private Long id;

    @OneToOne(targetEntity = Stock.class)
    private Stock stock;

    private Integer numberOfShares;
    private BigDecimal pricePerShare;

    private LocalDateTime purchaseDate;

    public Investment(Stock stock, Integer numberOfShares, BigDecimal pricePerShare,
                      LocalDateTime purchaseDate) {
        this.stock = stock;
        this.numberOfShares = numberOfShares;
        this.pricePerShare = pricePerShare;
        this.purchaseDate = purchaseDate;
    }

    public InvestmentRepresentation toInvestmentRepresentation() {
        return new InvestmentRepresentation(id, stock.getCompanyName());
    }

}
