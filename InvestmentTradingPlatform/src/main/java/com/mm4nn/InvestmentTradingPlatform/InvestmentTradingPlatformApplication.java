package com.mm4nn.InvestmentTradingPlatform;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@SpringBootApplication
@EnableJpaRepositories(basePackages = "com.mm4nn.InvestmentTradingPlatform.domain")
public class InvestmentTradingPlatformApplication {

    public static void main(String[] args) {
        SpringApplication.run(InvestmentTradingPlatformApplication.class, args);
    }

}
