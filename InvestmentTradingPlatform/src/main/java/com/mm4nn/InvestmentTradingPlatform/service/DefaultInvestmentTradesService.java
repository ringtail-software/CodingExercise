package com.mm4nn.InvestmentTradingPlatform.service;

import com.mm4nn.InvestmentTradingPlatform.StockMockTools;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.Investment;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentDetail;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.User;
import com.mm4nn.InvestmentTradingPlatform.domain.repository.InvestmentRepository;
import com.mm4nn.InvestmentTradingPlatform.domain.repository.UserRepository;
import com.mm4nn.InvestmentTradingPlatform.error.InvestmentNotFoundException;
import com.mm4nn.InvestmentTradingPlatform.error.UserNotFoundException;

import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.util.List;

/**
 * Implementation of the InvestmentTradesService interface
 */
@Service
public class DefaultInvestmentTradesService implements InvestmentTradesService {

    private final UserRepository userRepository;
    private final InvestmentRepository investmentRepository;

    public DefaultInvestmentTradesService(UserRepository userRepository, InvestmentRepository investmentRepository) {
        this.userRepository = userRepository;
        this.investmentRepository = investmentRepository;
    }

    @Override
    public List<Investment> getUserInvestments(long userId)
            throws UserNotFoundException {

        User user = userRepository.findById(userId)
                .orElseThrow(() -> new UserNotFoundException(userId));

        return user.getInvestments();

    }

    @Override
    public InvestmentDetail getInvestmentDetail(long investmentId)
            throws InvestmentNotFoundException {

        Investment investment = investmentRepository.findById(investmentId)
                .orElseThrow(() -> new InvestmentNotFoundException(investmentId));

        InvestmentDetail investmentDetail = new InvestmentDetail();

        investmentDetail.setStock(investment.getStock());
        investmentDetail.setNumberOfShares(investment.getNumberOfShares());
        investmentDetail.setPricePerShare(investment.getPricePerShare());
        investmentDetail.setPurchaseDate(investment.getPurchaseDate());

        investmentDetail.setCostBasisPerShare(investment.getPricePerShare());
        investmentDetail.setCurrentPrice(StockMockTools.getStockPrice(1.0f));
        investmentDetail.setTerm(StockMockTools.getInvestmentTerm(investment));

        BigDecimal initialValue = StockMockTools.getInitialValue(investment);
        BigDecimal currentValue =
                StockMockTools.getInvestmentValue(investment, investmentDetail.getCurrentPrice());

        investmentDetail.setInitialValue(initialValue);
        investmentDetail.setCurrentValue(currentValue);
        investmentDetail.setTotalLossOrGain(currentValue.subtract(initialValue));

        return investmentDetail;

    }

}
