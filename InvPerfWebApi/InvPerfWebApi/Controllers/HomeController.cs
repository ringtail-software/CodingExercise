using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvPerfWebApi.Models;
using InvPerfWebApi.ViewModels;
using System.Threading.Tasks;

namespace InvPerfWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private InvestmentDataProvider idp = new InvestmentDataProvider();

        public async Task<ActionResult> GetUserInvestmentDataAsync(string userName, string investmentName)
        {
            //Ideally the user should provide the user name and investment name to search for
            if (userName == null)
                userName = "User2";
            if (investmentName == null)
                investmentName = "Investment2";

            var tmp1 = await idp.GetAsync(userName);
            var tmp2 = await idp.GetAsync(userName, investmentName);
            var viewModel = new InvestmentDataViewModel
            {
                UserInvestments = tmp1,
                UserInvestmentDetails = tmp2
            };

            return View(viewModel);
        }
    }
}