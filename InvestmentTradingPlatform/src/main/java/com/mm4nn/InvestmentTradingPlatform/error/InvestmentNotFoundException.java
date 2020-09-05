package com.mm4nn.InvestmentTradingPlatform.error;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

/**
 * Exception thrown in API's when an investment is queried for that
 * does not exist.
 */
@ResponseStatus(value= HttpStatus.NOT_FOUND, reason="Could not find investment")
public class InvestmentNotFoundException extends RuntimeException {
    public InvestmentNotFoundException(Long id) {
        super(String.format("Could not find investment with id=%d", id));
    }
}
