using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace movie.Models
{
    public partial class MovieContext : DbContext
    {
        public MovieContext()
        {
        }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<MemberShip> MemberShips { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MemberShipId).HasColumnName("MemberShipID");

                entity.HasOne(d => d.MemberShip)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.MemberShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_MemberShip");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId)
                    .ValueGeneratedNever()
                    .HasColumnName("GenreID");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MemberShip>(entity =>
            {
                entity.ToTable("MemberShip");

                entity.Property(e => e.MemberShipId)
                    .ValueGeneratedNever()
                    .HasColumnName("MemberShipID");

                entity.Property(e => e.MemberShipName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.MovieContent).HasColumnType("text");

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Genre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
