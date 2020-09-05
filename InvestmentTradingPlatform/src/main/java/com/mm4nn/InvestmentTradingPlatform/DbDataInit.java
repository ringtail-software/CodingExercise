package com.mm4nn.InvestmentTradingPlatform;

import com.mm4nn.InvestmentTradingPlatform.domain.bean.Investment;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.Stock;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.User;
import com.mm4nn.InvestmentTradingPlatform.domain.repository.InvestmentRepository;
import com.mm4nn.InvestmentTradingPlatform.domain.repository.StockRepository;
import com.mm4nn.InvestmentTradingPlatform.domain.repository.UserRepository;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

import static com.mm4nn.InvestmentTradingPlatform.StockMockTools.getDate;
import static com.mm4nn.InvestmentTradingPlatform.StockMockTools.getInt;
import static com.mm4nn.InvestmentTradingPlatform.StockMockTools.getStockPriceAtTimeOfPurchase;

/**
 * Helper class used to populate the database with some useful
 * data. Enabled in developer mode only (profile == dev)
 *
 * Spring will automatically run any CommandLineRunner implementations
 * it finds in your package.
 */
@Component
@Profile("dev")
public class DbDataInit implements CommandLineRunner {

    private static final Logger LOG =
            LoggerFactory.getLogger(InvestmentTradingPlatformApplication.class);

    @Value("${spring.application.name}")
    private String applicationName;

    private final StockRepository stockRepository;
    private final UserRepository userRepository;
    private final InvestmentRepository investmentRepository;

    @Autowired
    public DbDataInit(StockRepository stockRepository,
                      UserRepository userRepository,
                      InvestmentRepository investmentRepository) {
        this.stockRepository = stockRepository;
        this.userRepository = userRepository;
        this.investmentRepository = investmentRepository;
    }

    @Override
    public void run(String... args) {

        preamble();

        populateStocks();
        populateUsers();

        listStocks();
        listUsers();
        listInvestments();

    }

    private void preamble() {
        LOG.info("");
        LOG.info("{} Application. CommandLineRunner executing...",
                applicationName);
        LOG.info("");
    }

    private void populateStocks() {

        // Don't duplicate data
        if (stockRepository.count() > 0) {
            LOG.info("Stocks table already contains data. Skipping...");
            LOG.info("");
            return;
        }

        // Populate the stock table
        LOG.info("Populating stocks...");
        stockRepository.save(new Stock("Amazon", "NASDAQ", "AMZN"));
        stockRepository.save(new Stock("Apple", "NASDAQ", "APPL"));
        stockRepository.save(new Stock("Cisco Systems", "NASDAQ", "CSCO"));
        stockRepository.save(new Stock("Ebay", "NASDAQ", "EBAY"));
        stockRepository.save(new Stock("Facebook", "NASDAQ", "FB"));
        stockRepository.save(new Stock("Google", "NASDAQ", "GOOG"));
        stockRepository.save(new Stock("IBM", "NASDAQ", "IBM"));
        stockRepository.save(new Stock("Intel", "NASDAQ", "INTC"));
        stockRepository.save(new Stock("Microsoft", "NASDAQ", "MSFT"));
        stockRepository.save(new Stock("Netflix", "NASDAQ", "NFLX"));
        stockRepository.save(new Stock("Square", "NYSE", "SQ"));
        stockRepository.save(new Stock("PayPal", "NASDAQ", "PYPL"));
        stockRepository.save(new Stock("Uber", "NYSE", "UBER"));
        LOG.info("");
    }

    private void listStocks() {
        LOG.info("Stocks in db:");
        LOG.info("-------------");
        for (Stock stock : stockRepository.findAll()) {
            LOG.info(stock.toString());
        }
        LOG.info("");
    }

    private void populateUsers() {

        // Don't duplicate data
        if (userRepository.count() > 0) {
            LOG.info("Users table already contains data. Skipping users and investments...");
            LOG.info("");
            return;
        }

        // Cache stocks so we do not need to retrieve them multiple times.
        List<Stock> stocks = new ArrayList<>(stockRepository.findAll());

        // Populate the user table
        LOG.info("Populating users:");
        userRepository.save(makeUser("Lucille", "Bluth", "ceo@bluthcompany.com", stocks));
        userRepository.save(makeUser("Charles", "Burns", "cmburns@springfieldnuclear.org", stocks));
        userRepository.save(makeUser("Jed", "Clampett", "jed@welllldoggie.org", stocks));
        userRepository.save(makeUser("Gordon", "Gekko", "gordon@greedisgood.biz", stocks));
        userRepository.save(makeUser("Thurston", "Howell", "thurston.howell@thurston-howell-corp.com", stocks));
        userRepository.save(makeUser("Charles", "Kane", "ckane@nydinquirer.com", stocks));
        userRepository.save(makeUser("Tywin", "Lannister", "lord.paramount@lannister.com", stocks));
        userRepository.save(makeUser("Lex", "Luthor", "lex@lexcorp.com", stocks));
        userRepository.save(makeUser("Lucius", "Malfoy", "lucious.malfoy@erols.com", stocks));
        userRepository.save(makeUser("Scrooge", "McDuck", "s.mcduck@mcduck.com", stocks));
        userRepository.save(makeUser("Richie", "Rich", "richie@rich.net", stocks));
        userRepository.save(makeUser("Lord", "Smaug", "lord.smaug@themountain.com", stocks));
        userRepository.save(makeUser("Tony", "Stark", "tony@stark.com", stocks));
        userRepository.save(makeUser("Adrian", "Veidt", "smartypants@veidt.com", stocks)); // Ozymandias
        userRepository.save(makeUser("Bruce", "Wayne", "bruce.wayne@wayne-enterprises.com", stocks));
        LOG.info("");

    }

    private User makeUser(String firstName, String lastName, String email,
                          List<Stock> stocks) {
        User user = new User(firstName, lastName, email);
        makeInvestments(user, stocks);
        return user;
    }

    private void listUsers() {
        LOG.info("Users in db:");
        LOG.info("------------");
        for (User user : userRepository.findAll()) {
            LOG.info(user.toString());
        }
        LOG.info("");
    }

    private void makeInvestments(User user, List<Stock> stocks) {

        int investmentCount = getInt(1, 100);

        LOG.info("Generating {} investments for {} {}...",
                investmentCount, user.getFirstName(), user.getLastName());

        List<Investment> investments = new ArrayList<>();
        for (int idx = 0; idx < investmentCount; ++idx) {
            Stock whichStock = stocks.get(getInt(1, stocks.size()) - 1);
            investments.add(new Investment(whichStock,
                    getInt(100, 10_000), getStockPriceAtTimeOfPurchase(),
                    getDate()));
        }
        user.setInvestments(investments);

    }

    private void listInvestments() {
        LOG.info("Investments in db:");
        LOG.info("------------");
        for (Investment investment : investmentRepository.findAll()) {
            LOG.info(investment.toString());
        }
        LOG.info("");
    }

}
