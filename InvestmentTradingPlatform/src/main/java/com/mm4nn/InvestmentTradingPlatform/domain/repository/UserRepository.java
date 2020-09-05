package com.mm4nn.InvestmentTradingPlatform.domain.repository;

import com.mm4nn.InvestmentTradingPlatform.domain.bean.User;

import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Repository used to access User data
 */
public interface UserRepository extends JpaRepository<User, Long> {

}
