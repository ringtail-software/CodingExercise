package com.mm4nn.InvestmentTradingPlatform.service;

import com.mm4nn.InvestmentTradingPlatform.domain.bean.Investment;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentDetail;
import com.mm4nn.InvestmentTradingPlatform.error.InvestmentNotFoundException;
import com.mm4nn.InvestmentTradingPlatform.error.UserNotFoundException;

import java.util.List;

/**
 * Interface for the InvestmentTradeService
 */
public interface InvestmentTradesService {

    /**
     * Returns a list of all the investments for the given user
     *
     * @param userId the ID of the user
     * @return list of Investment objects
     * @throws UserNotFoundException if the user is not found
     */
    List<Investment> getUserInvestments(long userId)
            throws UserNotFoundException;

    /**
     * Returns an object with details of a specific investment
     *
     * @param investmentId the ID of the investment
     * @return InvestmentDetails object
     * @throws InvestmentNotFoundException if the investment is not found
     */
    InvestmentDetail getInvestmentDetail(long investmentId)
            throws InvestmentNotFoundException;

}
