using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvPerfWebApi.Models;


namespace InvPerfWebApi
{
    //The api controller was intended for use by the Vue application. In the interest of time I did not finish this path, since 
    //I ran into a cors issue. I have not used Vue much. After I submit thit the project, I will spend some time to figure out the issue.
    //The methods can be tested in a browser:
    //https://localhost:44340/api/InvPerformance/?userName=User1
    //https://localhost:44340/api/InvPerformance/?userName=User1&investmentName=Investment1
    
    public class InvPerformanceController : ApiController
    {
        private InvestmentDataProvider idp = new InvestmentDataProvider();
        // GET: api/InvPerformance/"{userName}"
        public List<UserInvestment> Get(string userName)
        {
            return idp.getUserInvestments(userName);
           
        }

 
        // GET: api/InvPerformance/"{userName}, {investmentName}"
        public List<UserInvestmentDetail> Get(string userName, string investmentName)
        {
            return idp.getUserInvestmentDetail(userName, investmentName);
        }

     }
}
