using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ZachAlbertCodingExercise.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace ZachAlbertCodingExercise.Domain
{
    public class InvestmentContext : DbContext
    {
        private readonly string _connectionString;

        public InvestmentContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public InvestmentContext(DbContextOptions<InvestmentContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Investments> Investments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ_User_UserId")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasIndex(e => e.StockId)
                    .HasName("UQ_Stock_StockId")
                    .IsUnique();

                entity.Property(e => e.StockName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentPrice)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Investments>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ_Investments_Id")
                    .IsUnique();

                entity.Property(e => e.StockId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseAmount)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PurchasePrice)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

            });


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_connectionString);
            }
        }
    }
}