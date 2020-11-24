using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentPerformanceWebAPI.Models
{
    /// <summary>
    /// Represents a single investment for a user
    /// </summary>
    public class Investment
    {
        /// <summary>
        /// Investment Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Investment Name
        /// </summary>
        public string Name { get; set; }
    }
}