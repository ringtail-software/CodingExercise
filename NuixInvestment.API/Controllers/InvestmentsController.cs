using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NLog;
using System;

namespace NuixInvestment.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class InvestmentsController : ControllerBase
	{
		private readonly Logger log = LogManager.GetCurrentClassLogger();
		private readonly IConfiguration configuration;

		public InvestmentsController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		[HttpGet("{Id}")]
		public IActionResult Index(string Id)
		{
			try
			{
				var apiKey = HttpContext.Request.Headers["ApiKey"];
				var nuixApiKey = configuration["ApiKey"];
				if (apiKey == nuixApiKey)
				{
					// mock data
					var path = AppDomain.CurrentDomain.BaseDirectory;
					var json = System.IO.File.ReadAllText($"{path}/SampleData/investments.json");

					//var conn = configuration.GetConnectionString("FilevineConnection");
					//var query = $"uspNuix_GetUserInvestments {Id}";
					//using var cn = UtilData.OpenDefaultConn(conn);
					//var result = await cn.QueryAsync(query);
					//return Ok(result);

					return Ok(json);
				}
				return Unauthorized();
			}
			catch (Exception ex)
			{
				log.Error(ex.Message);
				throw;
			}
		}
	}
}