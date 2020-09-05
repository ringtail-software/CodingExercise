package com.mm4nn.InvestmentTradingPlatform.web.rest;

import com.mm4nn.InvestmentTradingPlatform.domain.bean.User;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.UserRepresentation;
import com.mm4nn.InvestmentTradingPlatform.domain.repository.UserRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.stream.Collectors;

/**
 * Implementation of the /api/users API
 */
@RestController
public class UserApi {

    private final UserRepository userRepository;

    @Autowired
    public UserApi(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @GetMapping("/api/users")
    public List<UserRepresentation> getAllUsers() {
        return userRepository.findAll().stream()
                .map(User::toUserRepresentation)
                .collect(Collectors.toList());
    }

}
