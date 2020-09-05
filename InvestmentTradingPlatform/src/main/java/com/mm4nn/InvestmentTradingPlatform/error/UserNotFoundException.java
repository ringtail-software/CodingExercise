package com.mm4nn.InvestmentTradingPlatform.error;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

/**
 * Exception thrown in API's when a user is queried for that
 * does not exist.
 */
@ResponseStatus(value= HttpStatus.NOT_FOUND, reason="Could not find user")
public class UserNotFoundException extends RuntimeException {
    public UserNotFoundException(Long id) {
        super(String.format("Could not find user with id=%d", id));
    }
}
