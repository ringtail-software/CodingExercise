namespace TradingApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using TradingApp.Data.Entities;

    /// <summary>
    /// An EF db context for accessing the trading app database.
    /// </summary>
    public class TradingAppContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TradingAppContext"/> class.
        /// </summary>
        /// <param name="options">The configuration options.</param>
        public TradingAppContext(DbContextOptions<TradingAppContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the investments data set.
        /// </summary>
        public DbSet<Investment> Investments { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investment>()
                .HasKey(x => x.Id);
        }
    }
}
