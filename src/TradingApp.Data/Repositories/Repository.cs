namespace TradingApp.Data.Repositories
{
    using System.Linq;

    /// <summary>
    /// A generic implementation of the <see cref="IRepository{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        private readonly TradingAppContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="db">The database context.</param>
        public Repository(TradingAppContext db)
        {
            this.db = db;
        }

        /// <inheritdoc />
        public T FindById(int id)
        {
            return this.db.Find<T>(id);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll()
        {
            return this.db.Set<T>();
        }
    }
}
