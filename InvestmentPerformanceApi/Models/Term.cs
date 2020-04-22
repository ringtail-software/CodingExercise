using System.Text.Json.Serialization;

namespace InvestmentPerformanceApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Term
    {
        /// <summary>
        /// Represents a term of 1 year or less
        /// </summary>
        Short,
        /// <summary>
        /// Represents a term of greater than 1 year
        /// </summary>
        Long
    }
}
