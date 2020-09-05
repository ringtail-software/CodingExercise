package com.mm4nn.InvestmentTradingPlatform.web.rest;

import com.mm4nn.InvestmentTradingPlatform.InvestmentTradingPlatformApplication;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentDetailRepresentation;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentRepresentation;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentTerm;
import com.mm4nn.InvestmentTradingPlatform.error.InvestmentNotFoundException;
import com.mm4nn.InvestmentTradingPlatform.error.UserNotFoundException;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.List;

import static org.hamcrest.Matchers.containsString;
import static org.mockito.ArgumentMatchers.anyLong;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@ExtendWith(MockitoExtension.class)
@SpringBootTest(classes = InvestmentTradingPlatformApplication.class)
class InvestmentPerformanceApiTest {

    private MockMvc mockMvc;

    @Mock
    private InvestmentPerformanceApi investmentPerformanceApi;

    @BeforeEach
    void setUp() {
        mockMvc = MockMvcBuilders
                .standaloneSetup(investmentPerformanceApi)
                .build();
    }

    @Test
    void getUsersInvestments() throws Exception {

        String expectedJson = """
            [
                {
                    "id": 1,
                    "name": "Apple"
                },
                {
                    "id": 2,
                    "name": "IBM"
                },
                {
                    "id": 3,
                    "name": "Intel"
                }
            ]
        """;

        Mockito.when(investmentPerformanceApi.getUsersInvestments(anyLong()))
                .thenReturn(getInvestments());
        mockMvc.perform(get("/api/investments/1"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(content().json(expectedJson))
                .andReturn();

    }

    @Test
    void getUsersInvestmentsWithError() throws Exception {

        Mockito.when(investmentPerformanceApi.getUsersInvestments(anyLong()))
                .thenThrow(new UserNotFoundException(1234L));
        mockMvc.perform(get("/api/investments/1234"))
                .andExpect(status().isNotFound())
                .andExpect(status().reason(containsString("Could not find user")))
                .andReturn();

    }

    @Test
    void getInvestmentDetail() throws Exception {

        String expectedJson = """
            {
                "numberOfShares": 15000,
                "costBasisPerShare": 4.70,
                "currentPrice": 99.99,
                "currentValue": 1485000.0,
                "term": "LONG_TERM",
                "totalLossOrGain": 1414500.0
            }
        """;

        Mockito.when(investmentPerformanceApi.getInvestmentDetail(anyLong()))
                .thenReturn(getInvestmentDetails());
        mockMvc.perform(get("/api/investment-detail/3"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(content().json(expectedJson))
                .andReturn();

    }

    @Test
    void getInvestmentDetailWithError() throws Exception {

        Mockito.when(investmentPerformanceApi.getInvestmentDetail(anyLong()))
                .thenThrow(new InvestmentNotFoundException(1234L));
        mockMvc.perform(get("/api/investment-detail/1234"))
                .andExpect(status().isNotFound())
                .andExpect(status().reason(containsString("Could not find investment")))
                .andReturn();

    }

    private List<InvestmentRepresentation> getInvestments() {
        InvestmentRepresentation apple = new InvestmentRepresentation(1, "Apple");
        InvestmentRepresentation ibm = new InvestmentRepresentation(2, "IBM");
        InvestmentRepresentation intel = new InvestmentRepresentation(3, "Intel");
        return List.of(apple, ibm, intel);
    }

    private InvestmentDetailRepresentation getInvestmentDetails() {

        InvestmentDetailRepresentation idr = new InvestmentDetailRepresentation();

        idr.setNumberOfShares(15_000);
        idr.setCostBasisPerShare(BigDecimal.valueOf(4.70)
                .setScale(2, RoundingMode.HALF_UP));
        idr.setCurrentPrice(BigDecimal.valueOf(99.99f)
                .setScale(2, RoundingMode.HALF_UP));
        idr.setCurrentValue(BigDecimal.valueOf(1_485_000.00f)
                .setScale(2, RoundingMode.HALF_UP));
        idr.setTerm(InvestmentTerm.LONG_TERM);
        idr.setTotalLossOrGain(BigDecimal.valueOf(1_414_500.00f)
                .setScale(2, RoundingMode.HALF_UP));

        return idr;

    }

}
