package com.mm4nn.InvestmentTradingPlatform.domain.repository;

import com.mm4nn.InvestmentTradingPlatform.domain.bean.Investment;

import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Repository used to access User's Investment data
 */
public interface InvestmentRepository extends JpaRepository<Investment, Long> {

}
