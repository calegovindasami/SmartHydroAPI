using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartHydroAPI.Models
{
    public partial class SmartHydroDbContext : DbContext
    {
        public SmartHydroDbContext()
        {
        }

        public SmartHydroDbContext(DbContextOptions<SmartHydroDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AiEvent> AiEvents { get; set; } = null!;
        public virtual DbSet<SensorReading> SensorReadings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:smarthydro.database.windows.net,1433;Initial Catalog=smarthydro;Persist Security Info=False;User ID=dev;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AiEvent>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("ai_events");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("date")
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SensorReading>(entity =>
            {
                entity.HasKey(e => e.ReadingId);

                entity.ToTable("sensor_readings");

                entity.Property(e => e.ReadingId).HasColumnName("readingId");

                entity.Property(e => e.Ec)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("ec");

                entity.Property(e => e.Humidity)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("humidity");

                entity.Property(e => e.LightIntensity)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("light_intensity");

                entity.Property(e => e.Ph)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("ph");

                entity.Property(e => e.Temperature)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("temperature");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WaterFlow)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("water_flow");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
