using System;
using System.ComponentModel;

namespace InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate
{
    /// <summary>
    /// Used for when a term is determined based on how long stock has been owned
    /// </summary>
    public enum Terms
    {
        [Description("<=1 year is short term")]
        Short = 1,

        [Description(">1 year is long term")]
        Long = 2
    }
}
