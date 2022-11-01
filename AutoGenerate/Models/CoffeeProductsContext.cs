using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AutoGenerate.Models
{
    public partial class CoffeeProductsContext : DbContext
    {
        public CoffeeProductsContext()
        {
        }

        public CoffeeProductsContext(DbContextOptions<CoffeeProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CoffeeProducts;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ProductName).HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
