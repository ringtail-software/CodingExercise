using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;

namespace NuixInvestment.Pages
{
	public class DetailModel : PageModel
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public string UserId { get; set; }

		public IActionResult OnGet()
		{
			try
			{
				//var userName = User.Identity.Name;
				// userId = UtilUser.GetStaffCodeByUserName(userName);
				UserId = "714";

				return Page();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				throw;
			}
		}
	}
}