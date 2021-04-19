using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NLog;
using System;

namespace NuixInvestment.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class DetailsController : ControllerBase
	{
		private readonly Logger _log = LogManager.GetCurrentClassLogger();
		private readonly IConfiguration configuration;

		public DetailsController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		[HttpGet]
		[Route("{Id}")]
		public IActionResult Index(string Id)
		{
			try
			{
				var apiKey = HttpContext.Request.Headers["ApiKey"];
				var nuixApiKey = configuration["ApiKey"];

				if (apiKey == nuixApiKey)
				{
					var path = AppDomain.CurrentDomain.BaseDirectory;
					var json = System.IO.File.ReadAllText($"{path}/SampleData/details.json");

					return Ok(json);
				}

				return Unauthorized();
			}
			catch (Exception ex)
			{
				_log.Error(ex.Message);
				throw;
			}
		}
	}
}