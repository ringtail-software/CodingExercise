package com.mm4nn.InvestmentTradingPlatform.web.rest;

import com.mm4nn.InvestmentTradingPlatform.InvestmentTradingPlatformApplication;
import com.mm4nn.InvestmentTradingPlatform.domain.bean.UserRepresentation;

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

import java.util.List;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@ExtendWith(MockitoExtension.class)
@SpringBootTest(classes = InvestmentTradingPlatformApplication.class)
class UserApiTest {

    private MockMvc mockMvc;

    @Mock
    private UserApi userApi;

    @BeforeEach
    void setUp() {
        mockMvc = MockMvcBuilders
                .standaloneSetup(userApi)
                .build();
    }

    @Test
    void getAllUsers() throws Exception {

        String expectedJson = """
            [
                {"id":1,"firstName":"Lucille","lastName":"Bluth","email":"ceo@bluthcompany.com"},
                {"id":2,"firstName":"Charles","lastName":"Burns","email":"cmburns@springfieldnuclear.org"},
                {"id":3,"firstName":"Jed","lastName":"Clampett","email":"jed@welllldoggie.org"},
                {"id":4,"firstName":"Gordon","lastName":"Gekko","email":"gordon@greedisgood.biz"},
                {"id":5,"firstName":"Thurston","lastName":"Howell","email":"thurston.howell@thurston-howell-corp.com"},
                {"id":6,"firstName":"Charles","lastName":"Kane","email":"ckane@nydinquirer.com"},
                {"id":7,"firstName":"Tywin","lastName":"Lannister","email":"lord.paramount@lannister.com"},
                {"id":8,"firstName":"Lex","lastName":"Luthor","email":"lex@lexcorp.com"},
                {"id":9,"firstName":"Lucius","lastName":"Malfoy","email":"lucious.malfoy@erols.com"},
                {"id":10,"firstName":"Scrooge","lastName":"McDuck","email":"s.mcduck@mcduck.com"},
                {"id":11,"firstName":"Richie","lastName":"Rich","email":"richie@rich.net"},
                {"id":12,"firstName":"Lord","lastName":"Smaug","email":"lord.smaug@themountain.com"},
                {"id":13,"firstName":"Tony","lastName":"Stark","email":"tony@stark.com"},
                {"id":14,"firstName":"Adrian","lastName":"Veidt","email":"smartypants@veidt.com"},
                {"id":15,"firstName":"Bruce","lastName":"Wayne","email":"bruce.wayne@wayne-enterprises.com"}
            ]
        """;

        Mockito.when(userApi.getAllUsers())
                .thenReturn(getUsers());
        mockMvc.perform(get("/api/users"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(content().json(expectedJson))
                .andReturn();

    }

    private List<UserRepresentation> getUsers() {
        UserRepresentation user01 = new UserRepresentation( 1,
                "Lucille", "Bluth", "ceo@bluthcompany.com");
        UserRepresentation user02 = new UserRepresentation( 2,
                "Charles", "Burns", "cmburns@springfieldnuclear.org");
        UserRepresentation user03 = new UserRepresentation( 3,
                "Jed", "Clampett", "jed@welllldoggie.org");
        UserRepresentation user04 = new UserRepresentation( 4,
                "Gordon", "Gekko", "gordon@greedisgood.biz");
        UserRepresentation user05 = new UserRepresentation( 5,
                "Thurston", "Howell", "thurston.howell@thurston-howell-corp.com");
        UserRepresentation user06 = new UserRepresentation( 6,
                "Charles", "Kane", "ckane@nydinquirer.com");
        UserRepresentation user07 = new UserRepresentation( 7,
                "Tywin", "Lannister", "lord.paramount@lannister.com");
        UserRepresentation user08 = new UserRepresentation( 8,
                "Lex", "Luthor", "lex@lexcorp.com");
        UserRepresentation user09 = new UserRepresentation( 9,
                "Lucius", "Malfoy", "lucious.malfoy@erols.com");
        UserRepresentation user10 = new UserRepresentation(10,
                "Scrooge", "McDuck", "s.mcduck@mcduck.com");
        UserRepresentation user11 = new UserRepresentation(11,
                "Richie", "Rich", "richie@rich.net");
        UserRepresentation user12 = new UserRepresentation(12,
                "Lord", "Smaug", "lord.smaug@themountain.com");
        UserRepresentation user13 = new UserRepresentation(13,
                "Tony", "Stark", "tony@stark.com");
        UserRepresentation user14 = new UserRepresentation(14,
                "Adrian", "Veidt", "smartypants@veidt.com");
        UserRepresentation user15 = new UserRepresentation(15,
                "Bruce", "Wayne", "bruce.wayne@wayne-enterprises.com");
        return List.of(user01, user02, user03, user04, user05, user06, user07,
                user08, user09, user10, user11, user12, user13, user14, user15);
    }

}
