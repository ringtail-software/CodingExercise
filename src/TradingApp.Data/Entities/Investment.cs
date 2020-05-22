namespace TradingApp.Data.Entities
{
    using System;

    /// <summary>
    /// The persisted investment entity.
    /// </summary>
    public class Investment : Entity
    {
        /// <summary>
        /// Gets or sets owner's user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of shares owned.
        /// </summary>
        public int Shares { get; set; }

        /// <summary>
        /// Gets or sets the original purchase price.
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// Gets or sets the original purchase date.
        /// </summary>
        public DateTime PurchaseDate { get; set; }
    }
}
