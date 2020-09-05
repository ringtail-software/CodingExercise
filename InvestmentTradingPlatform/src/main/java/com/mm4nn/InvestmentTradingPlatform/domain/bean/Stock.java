package com.mm4nn.InvestmentTradingPlatform.domain.bean;

import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Column;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 *  POJO used for encapsulation of stocks and entity handling in JPA
 */
@Setter
@Getter
@EqualsAndHashCode
@ToString
@NoArgsConstructor
@Entity
@Table(name = "T_STOCK")
public class Stock {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @EqualsAndHashCode.Exclude
    private Long id;

    private String companyName;
    private String exchange;

    @Column(unique = true)
    private String abbreviation;

    public Stock(String companyName, String exchange, String abbreviation) {
        this.companyName = companyName;
        this.exchange = exchange;
        this.abbreviation = abbreviation;
    }

}
