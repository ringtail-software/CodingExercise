package com.mm4nn.InvestmentTradingPlatform.domain.bean;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

/**
 *  DTO used for transfer of user data in API's
 */
@Data
@AllArgsConstructor
@NoArgsConstructor
public class UserRepresentation {
    private long id;
    private String firstName;
    private String lastName;
    private String email;
}
