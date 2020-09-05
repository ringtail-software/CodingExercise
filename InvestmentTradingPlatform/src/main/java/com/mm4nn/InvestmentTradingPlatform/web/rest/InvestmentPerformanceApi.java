package com.mm4nn.InvestmentTradingPlatform.web.rest;

import com.mm4nn.InvestmentTradingPlatform.domain.bean.Investment;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentDetail;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentDetailRepresentation;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentRepresentation;
import com.mm4nn.InvestmentTradingPlatform.error.InvestmentNotFoundException;
import com.mm4nn.InvestmentTradingPlatform.service.InvestmentTradesService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.stream.Collectors;

/**
 * Implementation of the following API's
 * - /api/investments/{userId}
 * - /api/investment-detail/{investmentId}
 */
@RestController
public class InvestmentPerformanceApi {

    private final InvestmentTradesService investmentTradesService;

    @Autowired
    InvestmentPerformanceApi(InvestmentTradesService investmentTradesService) {
        this.investmentTradesService = investmentTradesService;
    }

    @GetMapping("/api/investments/{userId}")
    public List<InvestmentRepresentation> getUsersInvestments(@PathVariable Long userId) {

        List<Investment> investments = investmentTradesService.getUserInvestments(userId);

        return investments.stream()
                .map(Investment::toInvestmentRepresentation)
                .collect(Collectors.toList());

    }

    @GetMapping("/api/investment-detail/{investmentId}")
    public InvestmentDetailRepresentation getInvestmentDetail(@PathVariable Long investmentId)
        throws InvestmentNotFoundException {

        InvestmentDetail investmentDetail = investmentTradesService.getInvestmentDetail(investmentId);
        return investmentDetail.toInvestmentDetailRepresentation();

    }

}
