using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using YemenExchangeApi.Models;

namespace YemenExchangeApi.Services
{
    public partial class ExchangeDbContext : DbContext
    {
        public ExchangeDbContext()
        {
        }

        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Transform> Transforms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<SummaryTransformReport> SummaryTransformReport { get; set; }
        public virtual DbSet<SummaryDailyReport> SummaryDailyReport{ get; set; }

        public virtual DbSet<SummarySpecialReport> SummarySpecialReport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ABBAS-ALBURAEE;Database=YemenExchangeDB;User Id=admins; Password=a772630;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SummaryTransformReport>()
                .ToView(nameof(SummaryTransformReport)).HasKey(e=>e.TransformNo);

            modelBuilder.Entity<SummaryDailyReport>()
                .ToView(nameof(SummaryDailyReport)).HasNoKey();

            modelBuilder.Entity<SummarySpecialReport>()
                .ToView(nameof(SummarySpecialReport)).HasKey(e => e.TransformNo);


            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Areas_Id");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Transform>(entity =>
            {
                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Transforms)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transforms_Areas_Id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Transforms)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transforms_Cities_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Transforms)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transforms_Companies_Id");

                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.TransformRecievers)
                    .HasForeignKey(d => d.RecieverId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.TransformSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transforms)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transforms_Users_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedAccount).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
