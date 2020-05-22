namespace TradingApp.Data.Repositories
{
    using System.Linq;

    /// <summary>
    /// Data access repository for a persisted entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface IRepository<T>
        where T : Entity
    {
        /// <summary>
        /// Get a queryable collection of all entities of the given type.
        /// </summary>
        /// <returns>Queryable of all entities.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Get an entity by id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity.</returns>
        T FindById(int id);
    }
}
