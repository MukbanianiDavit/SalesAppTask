using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SalesApp.Infrastructure.Data.Entities;

#nullable disable

namespace SalesApp.Infrastructure.Data
{
    public partial class SalesAppDbContext : DbContext
    {
        public SalesAppDbContext()
        {
        }

        public SalesAppDbContext(DbContextOptions<SalesAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("client_id");

                entity.Property(e => e.ClientFname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("client_fname");

                entity.Property(e => e.ClientLname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("client_lname");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("order_id");

                entity.Property(e => e.OrderAmount).HasColumnName("order_ammount");

                entity.Property(e => e.OrderClientId).HasColumnName("order_client_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderParentId).HasColumnName("order_parent_id");

                entity.Property(e => e.OrderSellerId).HasColumnName("order_seller_id");

                entity.HasOne(d => d.OrderClient)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__order_cl__4222D4EF");

                entity.HasOne(d => d.OrderSeller)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderSellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__order_se__4316F928");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.Property(e => e.SellerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("seller_id");

                entity.Property(e => e.SellerBossId).HasColumnName("seller_boss_id");

                entity.Property(e => e.SellerFname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("seller_fname");

                entity.Property(e => e.SellerLname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("seller_lname");

                entity.HasOne(d => d.SellerBoss)
                    .WithMany(p => p.InverseSellerBoss)
                    .HasForeignKey(d => d.SellerBossId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sellers__seller___3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
