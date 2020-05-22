namespace TradingApp.Data
{
    /// <summary>
    /// Base class for a persisted entity.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        public int Id { get; set; }
    }
}
