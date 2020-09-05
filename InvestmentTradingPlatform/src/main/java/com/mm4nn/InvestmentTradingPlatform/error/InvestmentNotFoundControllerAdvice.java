package com.mm4nn.InvestmentTradingPlatform.error;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.ResponseStatus;

/**
 * Global exception handler for the InvestmentNotFoundException exception
 */
@ControllerAdvice
public class InvestmentNotFoundControllerAdvice {

    @ResponseBody
    @ResponseStatus(HttpStatus.NOT_FOUND)
    @ExceptionHandler(InvestmentNotFoundException.class)
    String investmentNotFoundExceptionExceptionHandler(InvestmentNotFoundException err) {
        return err.getMessage();
    }

}
