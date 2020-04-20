// All API calls return data in JSON format
// Data structures are all in the Models folder.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Models;
using SampleWebAPI.Services;


namespace SampleWebAPI.Controllers
{
    public class InvestmentController : Controller
    {
        // This is the default route for the project. It will return all current clients.
        [Route("client/list")]
        public IActionResult GetAllClients()
        {
            return Ok(new InvestmentServices().GetAllClients());
        }

        // Returns all of the investments for Client ID = ClientId
        [Route("client/investment/list/{ClientId}")]
        public IActionResult GetAllInvestments(int ClientId)
        {
            return Ok(new InvestmentServices().GetAllInvestments(ClientId));
        }

        // Returns the investment details of  Investment Id = InvestmentId
        [Route("client/investment/detail/{InvestmentId}")]
        public IActionResult GetInvestmentDetail(int InvestmentId)
        {
            return Ok(new InvestmentServices().GetInvestmentDetail(InvestmentId));
        }

        // Returns the analysis of Investment Id = InvestmentId
        [Route("client/investment/analysis/{InvestmentId}")]
        public IActionResult GetInvestmentAnalysis(int InvestmentId)
        {
            return Ok(new InvestmentServices().GetInvestmentAnalysis(InvestmentId));
        }


    }
}
