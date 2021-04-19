using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NLog;
using NuixInvestment.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuixInvestment.Pages
{
	public class IndexModel : PageModel
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