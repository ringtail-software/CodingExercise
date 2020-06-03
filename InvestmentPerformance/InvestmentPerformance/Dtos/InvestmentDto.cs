using InvestmentPerformance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentPerformance.Dtos
{
    public class InvestmentDto
    {
        public string Name { get; set; }
        public InvestmentType Type { get; set; }
        public int Id { get; set; }

    }
}
