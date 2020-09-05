package com.mm4nn.InvestmentTradingPlatform.domain.repository;

import com.mm4nn.InvestmentTradingPlatform.domain.bean.Stock;

import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Repository used to access Stock data
 */
public interface StockRepository extends JpaRepository<Stock, Long> {

}
