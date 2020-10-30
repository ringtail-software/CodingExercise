using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace InvestmentPerformanceWebAPI
{
    public partial class InvestmentPerformanceWebAPITest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.txtXML.Text = "";
            string investorID = this.txtInvestorID.Text;
            string investmentID = this.txtInvestmentID.Text;
            this.lblMessage.Text = "";
            if (Page.IsValid)
            {
                InvestmentPerformance oInvestService = new InvestmentPerformance();
                if (investorID != "" && investmentID != "")
                    this.txtXML.Text = oInvestService.GetUserInvestmentDetails(investorID, investmentID);
                else if (investorID != "")
                    this.txtXML.Text = oInvestService.GetUserInvestments(investorID);
                else if (investorID == "")
                    this.lblMessage.Text = "Investor ID is required.";
                if (this.txtXML.Text.IndexOf("Error:", 0) != -1)
                {
                    this.lblMessage.Text = this.txtXML.Text.Replace("Error:","");
                    this.txtXML.Text = "";
                }
            }
        }
    }
}