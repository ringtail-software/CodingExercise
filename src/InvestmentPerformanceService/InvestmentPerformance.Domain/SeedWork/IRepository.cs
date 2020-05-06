using System;
namespace InvestmentPerformance.Domain.SeedWork
{
    /// <summary>
    /// Enforce the convention that each repository is related to a single aggregate by implementing a generic repository type.
    /// That way, it's explicit that you're using a repository to target a specific aggregate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
