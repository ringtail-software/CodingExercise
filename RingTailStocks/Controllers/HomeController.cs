using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RingTail;
using RingTailStocks.Models;
using Newtonsoft.Json;

namespace RingTailStocks.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public string Encrypt(string text) {
            return Nuix.General.Encrypt(text);
        }

        public async Task<IActionResult> CurrentInvestments(string userId) {
            if (string.IsNullOrEmpty(userId)) return View();
            var response = await WebApiHelper.GetUserStocks(userId);
            try {
                var stocks = JsonConvert.DeserializeObject<List<Stock>>(response);
                return View(stocks);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                ViewData["ErrorMessage"] = response;
                return View();
            }
        }

        public async Task<IActionResult> InvestmentDetails(string userId, string investmentId) {
            if (string.IsNullOrEmpty(userId)) return View();
            var investment = await WebApiHelper.GetUserStocksDetails(userId, investmentId);
            try {
                var stockDetails = JsonConvert.DeserializeObject<Stock>(investment);
                return View(stockDetails);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                ViewData["ErrorMessage"] = investment;
                return View();
            }
        }

        public async Task<JsonResult> StockDetails(string userId, string investmentId) {
            var investment = await WebApiHelper.GetUserStocksDetails(userId, investmentId);
            var stockDetails = JsonConvert.DeserializeObject<Stock>(investment);
            return Json(stockDetails);
        }
    }
}