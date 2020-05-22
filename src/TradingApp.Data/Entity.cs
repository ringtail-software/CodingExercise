namespace TradingApp.Data
{
    /// <summary>
    /// Base class for a persisted entity.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets the entity id.
        /// </summary>
        public int Id { get; internal set; }
    }
}
