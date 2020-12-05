using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NuixTrade.Models;
using System.Data;
using NLog;
using NuixTrade.DAL;
using NuixTradeWeb.DAL;

/*
Plans for future iterations
	- Ability to display in foreign currencies
	- Adjust calculations if user bought an investment at different dates with different values
	- Add paging for long list of investments
	- Add media queries to allow for mobile devices
*/

namespace NuixTradeWeb
{
	public partial class _Default : Page
	{
		private IEnumerable<UserInvestment> _userInvestments;
		private int _userId;
		private string _userName;
		private static Logger _nLogger = LogManager.GetCurrentClassLogger();

		protected void Page_Load(object sender, EventArgs e)
		{
			_nLogger.Trace("Start Page_Load");
			// ====================
			// Assume this is part of a larger system, and the user is already logged in
			// _userId = int.Parse(Session["UserId"].ToString());
			// _userName = Session["UserName"].ToString();
			// 
			_userId = 4321;
			_userName = "Amanda Lorian";
			// ====================

			errorLabel.InnerText = string.Empty;
			userName.InnerText = _userName;
			IDataRepository dataRepository = DataRepositoryFactory.GetDataRepository(_nLogger);
			if (dataRepository == null)
			{
				errorLabel.InnerText = "There is a problem accessing the information.  Please try again later";
				_nLogger.Warn("Data Repository is missing");
			}
			else
				DisplayAllInvestments(dataRepository);
		}

		private void DisplayAllInvestments(IDataRepository dataRepository)
		{
			try
			{
				_userInvestments = dataRepository.GetAllUserInvestments(_userId);
				if (_userInvestments == null || _userInvestments.Count() == 0)
				{
					errorLabel.InnerText = "No active investments";
					_nLogger.Warn("No active investments");
					return;
				}

				using (DataTable data = new DataTable())
				{
					data.Columns.AddRange(new DataColumn[3]
						{
						new DataColumn("Id", typeof(string)),
						new DataColumn("Name", typeof(string)),
						new DataColumn("Get Details", typeof(string))
						});

					foreach (UserInvestment userInvestment in _userInvestments)
					{
						InvestmentProduct product = userInvestment.GetInvestmentProduct();
						data.Rows.Add(product.Id, product.Name);
					}
					PortfolioGridView.CellPadding = 50;
					PortfolioGridView.DataSource = data;
					PortfolioGridView.DataBind();
				}
			}
			catch (Exception ex)
			{
				errorLabel.InnerText = "The site is experiences technical issues.  Please try again later";
				_nLogger.Fatal(ex, $"Exception in 'DisplayAllInvestments' method");
			}
		}

		/// <summary>
		/// Add a "Select" data button beside each investment
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void PortfolioGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton getDetailsButton = new LinkButton();
				getDetailsButton.ID = e.Row.Cells[0].Text;
				getDetailsButton.Text = "Select";
				getDetailsButton.Click += new EventHandler(itemClicked);
				e.Row.Cells[2].Controls.Add(getDetailsButton);
			}
		}

		/// <summary>
		/// Triggers the display of investment details that the user selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void itemClicked(object sender, EventArgs e)
		{
			try
			{
				int investmentId = Int32.Parse(((LinkButton)sender).ID);

				UserInvestment selectedInvestment = _userInvestments.First(x => x.GetInvestmentProduct().Id == investmentId);
				if (selectedInvestment == null)
				{
					errorLabel.InnerText = "Error retrieving company details";
					_nLogger.Warn($"Unable to retrieve investment details for InvestmentId = {investmentId}");
				}
				else
					DisplayInvestmentDetails(selectedInvestment);
			}
			catch (Exception ex)
			{
				errorLabel.InnerText = "Internal exception retrieving company details";
				_nLogger.Error(ex, $"Exception processing item click");
			}
		}

		private void DisplayInvestmentDetails(UserInvestment selectedInvestment)
		{
			try
			{
				InvestmentProduct product = selectedInvestment.GetInvestmentProduct();
				TradeTransaction transaction = selectedInvestment.GetPurchaseTransaction();
				investmentName.InnerText = product.Name;
				numShares.InnerText = transaction.NumShares.ToString(); ;
				costBasisPerShare.InnerText = selectedInvestment.GetCostPerBasisShare().ToString("C3");
				currentValue.InnerText = selectedInvestment.GetCurrentValue().ToString("C3");
				currentPrice.InnerText = product.CurrentPrice.ToString("C3");
				term.InnerText = selectedInvestment.GetTerm().ToString();
				totalGainLoss.InnerText = selectedInvestment.GetTotalGainLoss().ToString("C3");

				_nLogger.Info($"Displaying details for {product.Name}");
			}
			catch (Exception ex)
			{
				errorLabel.InnerText = "Error displaying investment details.  Please try again later";
				_nLogger.Error(ex, "Exception displaying investment details");
			}
		}
	}
}
