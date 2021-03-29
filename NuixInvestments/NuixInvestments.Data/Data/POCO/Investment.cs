using System;
using System.Collections.Generic;
using System.Text;

namespace NuixInvestments.MiddleWare.Data.POCO
{
    public class Investment
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Abbreviation { get; set; }
        public decimal CurrentPrice { get; set; }

    }
}
