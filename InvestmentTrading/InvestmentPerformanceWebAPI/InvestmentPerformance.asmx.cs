using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessObjects;
using System.Text;
using System.Xml.Serialization;

namespace InvestmentPerformanceWebAPI
{
    /// <summary>
    /// Investment Performance is a web service which includes two methods:
    /// GetUserInvestmentDetails which accept investor ID and investment ID, 
    /// return the investment details of the user: number of shares, cost basis per share, current value, current price, term, and total gain/loss. 
    /// and GetUserInvestments which accept investor ID,
    /// return a list of investment the user made: ID and Name
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class InvestmentPerformance : System.Web.Services.WebService
    {
        private API myAPI;
        public InvestmentPerformance():base()
        { myAPI = new API(); }
        /// <summary>
        /// This API call will return an XML string of the investment details: number of shares, cost basis per share, current value, current price, term, and total gain/loss. 
        /// for valid investor ID and valid investment ID which the investor invested.
        /// </summary>
        /// <param name="investorID"></param>
        /// <param name="investmentID"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetUserInvestmentDetails(string investorID, string investmentID)
        {
            
            try { Convert.ToInt32(investorID); }
            catch
            { return "Invalid InvestorID, it must be an integer."; }

            try { Convert.ToInt32(investmentID); }
            catch
            { return "Invalid investment ID, it must be an integer."; }

            Investment userInvestmentDetail = null;
            try
            {
                userInvestmentDetail = myAPI.GetInvestmentDetails(Convert.ToInt32(investorID), Convert.ToInt32(investmentID));
            }catch (Exception ex)
            { return "Error: Failed to retrieve the investment details-" + ex.Message+"."; }

            if (userInvestmentDetail != null)
            {
                XmlSerializer x = new XmlSerializer(userInvestmentDetail.GetType());
                System.IO.StringWriter stringwriter = new System.IO.StringWriter();
                x.Serialize(stringwriter, userInvestmentDetail);
                return stringwriter.ToString();
            }
            else { return "Error: No Data Returned.";
            }
        }

        /// <summary>
        /// / This API call will return an XML string of a list of investments.
        /// for the valid investor, the list will show the ID and Name for each investment
        /// </summary>
        /// <param name="investorID"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetUserInvestments(string investorID)
        {
            try { Convert.ToInt32(investorID); }
            catch
            { return "Invalid InvestorID, it must be an integer."; }
            List<Stock> stocks;
            try {
                stocks = myAPI.GetInvestments(Convert.ToInt32(investorID));
            }
            catch (Exception ex)
            { return "Error: Failed to retrieve the investments-" + ex.Message + "."; }

            if (stocks.Count == 0)
            { return "Error: No Data Returned."; }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Stock>));

                var stringwriter = new System.IO.StringWriter();
                serializer.Serialize(stringwriter, stocks);
                return stringwriter.ToString();
            }
        }
    }
}
