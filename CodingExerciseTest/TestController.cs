using Xunit;
using CodingExercise.Controllers;
using Microsoft.AspNetCore.Mvc;
using CodingExercise.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodingExerciseTest
{
    public class TestController : Controller
    {

        [Fact]
        public void UserInvestment_UserInvestments_OK()
        {

            UserInvestmentController controller = new UserInvestmentController();            

            var result = controller.Get();
            Assert.IsType<OkObjectResult>(result);

            var resultData = result as OkObjectResult;
            var investments = resultData.Value as IEnumerable<InvestmentDTO>;

            Assert.Equal("Tesla", investments.First().Name);
        }

        [Fact]
        public void UserInvestment_DetailInvestment_OK()
        {
            UserInvestmentController controller = new UserInvestmentController();

            var result = controller.Detail(2);
            Assert.IsType<OkObjectResult>(result);

            var resultData = result as OkObjectResult;
            var investment = resultData.Value as InvestmentDTO;

            Assert.Equal(500, investment.NumberOfShares);
        }

        [Fact]
        public void UserInvestment_DetailInvestment_NotFound()
        {
            UserInvestmentController controller = new UserInvestmentController();

            var result = controller.Detail(4);
            Assert.IsType<NotFoundResult>(result);

        }
    }
}
