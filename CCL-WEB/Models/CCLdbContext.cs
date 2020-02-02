using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CCL_WEB.Models
{
    public partial class CCLdbContext : DbContext
    {
        public CCLdbContext()
        {
        }

        public CCLdbContext(DbContextOptions<CCLdbContext> options)
            : base(options)
        {
        }

        public DbSet<Year> Year { get; set; }
        public DbSet<Make> make { get; set; }
        public DbSet<Model> model { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<Listing> Listing { get; set; }
        public virtual DbSet<Log> Log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.DateVisited).HasColumnName("DateVisited");

                entity.Property(e => e.DealerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DealerUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ListingId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Listing>(entity =>
            {
                entity.Property(e => e.DealerName).HasMaxLength(500);

                entity.Property(e => e.Engine).HasMaxLength(100);

                entity.Property(e => e.ListingId)
                    .IsRequired()
                    .HasColumnName("ListingID")
                    .HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.Make).HasMaxLength(200);

                entity.Property(e => e.Model).HasMaxLength(200);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.StockNumber).HasMaxLength(100);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Transmission).HasMaxLength(200);

                entity.Property(e => e.Vin).HasMaxLength(100);

                entity.Property(e => e.Year).HasMaxLength(100);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.LogMessage).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
