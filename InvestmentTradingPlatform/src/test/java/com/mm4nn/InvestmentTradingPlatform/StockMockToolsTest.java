package com.mm4nn.InvestmentTradingPlatform;

import com.mm4nn.InvestmentTradingPlatform.domain.bean.Investment;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentTerm;

import org.junit.Assert;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;

import java.math.BigDecimal;
import java.time.LocalDateTime;

@ExtendWith(MockitoExtension.class)
class StockMockToolsTest {

    @Mock
    private Investment investment;

    @Test
    void getInt() {
        int i = StockMockTools.getInt(10, 20);
        Assert.assertTrue(i >= 10 && i <= 20);
        i = StockMockTools.getInt(10, 100);
        Assert.assertTrue(i >= 10 && i <= 100);
        i = StockMockTools.getInt(33, 999);
        Assert.assertTrue(i >= 33 && i <= 999);
    }

    @Test
    void getDate() {
        LocalDateTime then = LocalDateTime.now()
                .minusMonths(72)
                .minusDays(28)
                .minusHours(23)
                .minusMinutes(59);
        for (int idx = 0; idx < 1_000; ++idx) {
            Assert.assertTrue(StockMockTools.getDate().isAfter(then));
        }
    }

    void testGetFloat(float l, float h) {
        float f = StockMockTools.getFloat(l, h);
        Assert.assertTrue(f >= l && f <= h);
    }

    @Test
    void getFloat() {
        testGetFloat(10.0f, 20.0f);
        testGetFloat(10.0f, 100.f);
        testGetFloat(33.33f, 999.99f);
        testGetFloat(100.0f, 1_000.0f);
        testGetFloat(0.001f, 0.999f);
    }

    @Test
    void getStockPriceAtTimeOfPurchase() {

        final BigDecimal TEN = BigDecimal.valueOf(10.0);
        final BigDecimal ONE_HUNDRED = BigDecimal.valueOf(100.0);

        int count = 0;
        while (count++ < 100) {
            BigDecimal price =
                    StockMockTools.getStockPriceAtTimeOfPurchase();
            Assert.assertTrue(price.compareTo(TEN) >= 0
                    && price.compareTo(ONE_HUNDRED) <= 0);
        }

    }

    @Test
    void getStockPrice() {
        BigDecimal d = StockMockTools.getStockPrice(1.0f);
        Assert.assertTrue(d.compareTo(BigDecimal.ONE) >= 0);
        d = StockMockTools.getStockPrice(1_000.0f);
        Assert.assertTrue(d.compareTo(BigDecimal.valueOf(1_000)) >= 0);
    }

    @Test
    void getInitialValue() {
        Mockito.when(investment.getNumberOfShares()).thenReturn(7525);
        Mockito.when(investment.getPricePerShare())
                .thenReturn(BigDecimal.valueOf(35.85));
        BigDecimal v = StockMockTools.getInitialValue(investment);
        Assert.assertEquals(0, v.compareTo(BigDecimal.valueOf(269_771.25)));
    }

    @Test
    void getInvestmentValue() {
        Mockito.when(investment.getNumberOfShares()).thenReturn(7525);
        BigDecimal v = StockMockTools.getInvestmentValue(investment,
                BigDecimal.valueOf(15.99));
        Assert.assertEquals(0, v.compareTo(BigDecimal.valueOf(120_324.75)));
    }

    @Test
    void getInvestmentTerm() {
        Mockito.when(investment.getPurchaseDate())
                .thenReturn(LocalDateTime.of(1999, 12, 1, 10, 0, 0));
        Assert.assertEquals(InvestmentTerm.LONG_TERM,
                StockMockTools.getInvestmentTerm(investment));
        Mockito.when(investment.getPurchaseDate())
                .thenReturn(LocalDateTime.now().minusMonths(3));
        Assert.assertEquals(InvestmentTerm.SHORT_TERM,
                StockMockTools.getInvestmentTerm(investment));
    }

}
