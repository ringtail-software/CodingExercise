using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RingTail.Attributes;
using RingTail.Data;

namespace RingTail.Controllers {
    [ApiController]
    [Route("[controller]/[action]")]
    [ApiKey]
    public class Investments : ControllerBase {
        [HttpGet]
        public IEnumerable<object> UserStocks(string userId) {
            if (string.IsNullOrEmpty(userId)) throw new Exception("User not Specified");
            int.TryParse(userId, out var clientId);
            return InvestmentData.GetUserStocks(clientId);
        }

        public IInvestment UserStocksByStock(string userId, string investmentId) {
            if (string.IsNullOrEmpty(userId)) throw new Exception("User not Specified");
            if (string.IsNullOrEmpty(investmentId)) throw new Exception("Stock not Specified");
            int.TryParse(userId, out var clientId);
            int.TryParse(investmentId, out var investmentNumber);
            return InvestmentData.GetUserStocks(clientId, investmentNumber);
        }
    }
}