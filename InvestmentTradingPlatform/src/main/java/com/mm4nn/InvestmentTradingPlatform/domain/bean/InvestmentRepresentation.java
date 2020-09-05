package com.mm4nn.InvestmentTradingPlatform.domain.bean;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

/**
 *  DTO used for transfer of user's investments in API's
 */
@Data
@AllArgsConstructor
@NoArgsConstructor
public class InvestmentRepresentation {
    private long id;
    private String name;
}
