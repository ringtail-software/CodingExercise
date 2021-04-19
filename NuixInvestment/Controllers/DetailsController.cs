using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NuixInvestment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DetailsController : ControllerBase
	{
		private readonly Logger _log = LogManager.GetCurrentClassLogger();
		private readonly HttpClient client;
		private readonly string apiUrl;
		private readonly string apiKey;

		public DetailsController(IConfiguration configuration, IHttpClientFactory factory)
		{
			client = factory.CreateClient();
			apiUrl = configuration["BaseUrl"];
			apiKey = configuration["APIKey"];
		}

		[HttpGet]
		[Route("{Id}")]
		public async Task<IActionResult> Index(string Id)
		{
			try
			{
				client.DefaultRequestHeaders.Add("ApiKey", apiKey);
				var response = await client.GetAsync($"{apiUrl}/Details/{Id}");
				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					return Ok(result);
				}

				return BadRequest(response.Content);
			}
			catch (Exception ex)
			{
				_log.Error(ex.Message);
				throw;
			}
		}
	}
}