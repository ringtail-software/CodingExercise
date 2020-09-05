package com.mm4nn.InvestmentTradingPlatform.service;

import com.mm4nn.InvestmentTradingPlatform.domain.bean.Investment;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentDetail;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentTerm;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.Stock;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.User;
import com.mm4nn.InvestmentTradingPlatform.domain.repository.InvestmentRepository;
import com.mm4nn.InvestmentTradingPlatform.domain.repository.UserRepository;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.testng.Assert;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;

import static org.mockito.ArgumentMatchers.anyLong;
import static org.mockito.Mockito.times;

@ExtendWith(MockitoExtension.class)
class DefaultInvestmentTradesServiceTest {

    @Mock
    private UserRepository userRepository;

    @Mock
    private InvestmentRepository investmentRepository;

    private InvestmentTradesService investmentTradesService;

    @BeforeEach
    void setUp() {
        investmentTradesService =
                new DefaultInvestmentTradesService(userRepository, investmentRepository);
    }

    @Test
    void getUserInvestments() {

        Stock appleStock = new Stock("Apple", "NASDAQ", "APPL");
        Stock ibmStock = new Stock("IBM", "NASDAQ", "IBM");
        Stock intelStock = new Stock("Intel", "NASDAQ", "INTC");

        Investment appleInvestment = new Investment(appleStock, 3_100,
                BigDecimal.valueOf(7.75), LocalDateTime.of(2010, 6, 6, 14, 35, 15));
        Investment ibmInvestment = new Investment(ibmStock, 5_000,
                BigDecimal.valueOf(11.50), LocalDateTime.of(1995, 2, 10, 10, 10, 15));
        Investment intelInvestment = new Investment(intelStock, 15_000,
                BigDecimal.valueOf(4.70), LocalDateTime.of(1995, 12, 1, 10, 5, 15));

        User user = new User("Reaganomics", "Lamborghini", "r.lambo@billions.biz");
        user.setInvestments(List.of(appleInvestment, ibmInvestment, intelInvestment));

        Mockito.when(userRepository.findById(anyLong()))
                .thenReturn(Optional.of(user));

        List<Investment> investments
                = investmentTradesService.getUserInvestments(1);

        Mockito.verify(userRepository, times(1)).findById(anyLong());

        Assert.assertEquals(user.getInvestments().size(),
                investments.size());

    }

    @Test
    void getInvestmentDetail() {

        Stock intelStock = new Stock("Intel", "NASDAQ", "INTC");

        Investment intelInvestment = new Investment(intelStock, 15_000,
                BigDecimal.valueOf(4.70), LocalDateTime.of(1995, 12, 1, 10, 5, 15));

        Mockito.when(investmentRepository.findById(anyLong()))
                .thenReturn(Optional.of(intelInvestment));

        InvestmentDetail investmentDetail =
                investmentTradesService.getInvestmentDetail(3);

        Mockito.verify(investmentRepository, times(1)).findById(anyLong());

        Assert.assertEquals(intelStock, investmentDetail.getStock());
        Assert.assertEquals(intelInvestment.getNumberOfShares(),
                investmentDetail.getNumberOfShares());
        Assert.assertEquals(intelInvestment.getPricePerShare(),
                investmentDetail.getPricePerShare());

        Assert.assertEquals(intelInvestment.getPurchaseDate(),
                investmentDetail.getPurchaseDate());

        Assert.assertEquals(intelInvestment.getPricePerShare(),
                investmentDetail.getCostBasisPerShare());

        BigDecimal numberOfShares
                = BigDecimal.valueOf(investmentDetail.getNumberOfShares());
        BigDecimal originalPrice = investmentDetail.getCostBasisPerShare();
        BigDecimal currentPrice = investmentDetail.getCurrentPrice();

        BigDecimal initialValue = numberOfShares
                .multiply(originalPrice).setScale(2, RoundingMode.HALF_UP);
        Assert.assertEquals(initialValue, investmentDetail.getInitialValue());

        BigDecimal currentValue = numberOfShares
                .multiply(currentPrice).setScale(2, RoundingMode.HALF_UP);
        Assert.assertEquals(currentValue, investmentDetail.getCurrentValue());

        Assert.assertEquals(InvestmentTerm.LONG_TERM,
                investmentDetail.getTerm());

        Assert.assertEquals(currentValue.subtract(initialValue),
                investmentDetail.getTotalLossOrGain());

    }

}
