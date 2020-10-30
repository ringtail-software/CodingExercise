using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace InvestmentTrading
{
    public partial class InvestmentPerformanceTesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetInvestment_Click(object sender, EventArgs e)
        {
            InvestmentPerformance oInvestPerform = new InvestmentPerformance();
            string userID = this.txtInvestorID.Text;
            string investmentID = this.txtInvestmentID.Text;
            if (investmentID != "")
            { Investment invest = oInvestPerform.GetUserInvestmentDetails(Convert.ToInt32(userID), Convert.ToInt32(investmentID)); }
            else { List<Investment> investments = oInvestPerform.GetUserInvestments(Convert.ToInt32(userID)); }

        }
    }
}