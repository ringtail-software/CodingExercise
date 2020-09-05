import com.mm4nn.InvestmentTradingPlatform.StockMockTools
import com.mm4nn.InvestmentTradingPlatform.domain.bean.Investment
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentDetail
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentDetailRepresentation
import com.mm4nn.InvestmentTradingPlatform.domain.bean.InvestmentRepresentation
import com.mm4nn.InvestmentTradingPlatform.domain.bean.Stock
import com.mm4nn.InvestmentTradingPlatform.domain.bean.User
import com.mm4nn.InvestmentTradingPlatform.domain.bean.UserRepresentation
import com.mm4nn.testing.TestHelper
import spock.lang.Specification

class GoodApiSpecification extends Specification {

    def "Good API"() {

        expect:
        TestHelper.isGoodPojo(Stock)
        TestHelper.isGoodPojo(User)
        TestHelper.isGoodPojo(Investment)
        TestHelper.isGoodPojo(UserRepresentation)
        TestHelper.isGoodPojo(InvestmentRepresentation)
        TestHelper.isGoodPojo(InvestmentDetail)
        TestHelper.isGoodPojo(InvestmentDetailRepresentation)

        TestHelper.isGoodHelperClass(StockMockTools)

    }

}
