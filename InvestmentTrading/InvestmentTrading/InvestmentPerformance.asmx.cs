using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessObjects;

namespace InvestmentTrading
{
    /// <summary>
    /// Summary description for InvestmentPerformance
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class InvestmentPerformance : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Investment> GetUserInvestments(int investorID)
        {
            List<Investment> userInvestments = null;
            Investor user = new Investor(investorID);
            if (investorID==1 || investorID == 2)
            {
                userInvestments = user.investments;
            }
            
            return userInvestments;
        }
        [WebMethod]
        public Investment GetUserInvestmentDetails(int investorID, int investmentID)
        {
            Investment userInvestmentDetail = null;
            Investor user = new Investor(investorID);
            if (investorID == 1 || investorID == 2)
            {
                if(investmentID==1 || investmentID==2)
                userInvestmentDetail = user.GetInvestmentDetail(investmentID);
            }

            return userInvestmentDetail;
        }

    }
}
