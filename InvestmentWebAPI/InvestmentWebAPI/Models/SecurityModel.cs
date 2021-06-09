using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investment.API.Models
{
    public class SecurityModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public decimal CurrentPrice { get; set; }
    }
}
