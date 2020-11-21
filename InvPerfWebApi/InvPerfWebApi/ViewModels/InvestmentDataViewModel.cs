using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvPerfWebApi.Models;

namespace InvPerfWebApi.ViewModels
{
    public class InvestmentDataViewModel
    {
        public List<UserInvestment> UserInvestments { get; set; }
        public List<UserInvestmentDetail> UserInvestmentDetails { get; set; }
    }
}