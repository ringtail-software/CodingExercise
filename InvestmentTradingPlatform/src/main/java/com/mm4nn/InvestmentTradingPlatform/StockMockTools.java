package com.mm4nn.InvestmentTradingPlatform;

import com.google.common.base.Preconditions;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.Investment;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentTerm;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.time.LocalDateTime;
import java.util.Random;

/**
 * A helper class used to mock certain aspects of the application that
 * are needed (generating stock prices) and provide methods for calculating
 * investment details needed by the API's
 */
public final class StockMockTools {

    private static final Random random = new Random();

    // Just a helper class
    private StockMockTools() {

    }

    /**
     * Returns a random integer between min <= x <= max
     *
     * @param min minimum value
     * @param max maximum value
     * @return integer between min <= x <= max
     */
    public static int getInt(int min, int max) {
        Preconditions.checkArgument(min < max, "min must be less than max");
        float f = random.nextFloat();
        return min + (int) (f * (max - min));
    }

    /**
     * Returns a LocalDateTime object whose value is sometime between now
     * and 72 months, 28 days, 23 hours and 59 seconds ago.
     *
     * @return LocalDateTime
     */
    public static LocalDateTime getDate() {
        return LocalDateTime.now()
                .minusMonths(getInt(1, 72))
                .minusDays(getInt(1, 28))
                .minusHours(getInt(1, 23))
                .minusMinutes(getInt(33, 59));
    }

    /**
     * Returns a random float between min <= x <= max
     *
     * @param min minimum value
     * @param max maximum value
     * @return float between min <= x <= max
     */
    public static float getFloat(float min, float max) {
        Preconditions.checkArgument(min < max, "min must be less than max");
        float f = random.nextFloat();
        return min + f * (max - min);
    }

    /**
     * Returns a random BigDecimal whose value is between 10.00 <= value <= 100.00
     *
     * @return BigDecimal whose value is between 10.00 <= value <= 100.00
     */
    public static BigDecimal getStockPriceAtTimeOfPurchase() {
        // For the sake of this exercise all of our stocks will have
        // an initial price that's somewhat lower when our billionaires
        // decided to invest.
        float f = getFloat(10.0f, 100.00f);
        return BigDecimal.valueOf(f).setScale(2, RoundingMode.HALF_UP);
    }

    /**
     * Returns a random BigDecimal whose value is between 0.00 < value <= 5,000.00
     *
     * @param min minimum value--Must be 0 < min <= 1,000.00
     * @return BigDecimal whose value is between 0.00 < value <= 5,000.00
     */
    public static BigDecimal getStockPrice(float min) {
        // For this exercise allow a minimum but not zero.
        Preconditions.checkArgument(min > 0f, "minimum must be > 0");
        Preconditions.checkArgument(min <= 1_000f, "minimum must be <= 1,000");
        float f = getFloat(min, 5_000.0f);
        return BigDecimal.valueOf(f).setScale(2, RoundingMode.HALF_UP);
    }

    /**
     * Return the initial value of the investment.
     *
     * @param investment The Investment instance
     * @return BigDecimal initial value of investment.
     */
    public static BigDecimal getInitialValue(Investment investment) {
        BigDecimal value = investment.getPricePerShare()
                .multiply(BigDecimal.valueOf(investment.getNumberOfShares()));
        return value.setScale(2, RoundingMode.HALF_UP);
    }

    /**
     * Return the current value of the investment.
     *
     * @param investment The investment instance
     * @param currentPrice BigDecimal price of one share of the investment's stock
     * @return BigDecimal current value of the investment
     */
    public static BigDecimal getInvestmentValue(Investment investment, BigDecimal currentPrice) {
        BigDecimal value = currentPrice
                .multiply(BigDecimal.valueOf(investment.getNumberOfShares()));
        return value.setScale(2, RoundingMode.HALF_UP);
    }

    /**
     * Return the term of the investment based on it's purchase date.
     *
     * @param investment The investment instance
     * @return InvestmentTerm
     */
    public static InvestmentTerm getInvestmentTerm(Investment investment) {
        LocalDateTime oneYearAgo = LocalDateTime.now().minusYears(1);
        return investment.getPurchaseDate().isBefore(oneYearAgo)
                ? InvestmentTerm.LONG_TERM : InvestmentTerm.SHORT_TERM;
    }
}
