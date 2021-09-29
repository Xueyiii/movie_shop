using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using ApplicationCore.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {
            
        }
        // have all the Dbsets as properties with entity types.
        // Migrations

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<User> Users { get; set; }

        //Fluent API way of modeling the database
        //override onModelCreating+Tab
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<User>(ConfigureUser);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
            builder.Property(u => u.PhoneNumber).HasMaxLength(16);
            builder.Property(u => u.AccessFailedCount).HasColumnType(null);
        }

        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(f => f.Id);
            builder.HasOne(f => f.Movie).WithMany(m => m.Favorites).HasForeignKey(f => f.MovieId);
            builder.HasOne(f => f.User).WithMany(u => u.Favorites).HasForeignKey(f => f.UserId);
        }

        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(r => new {r.MovieId, r.UserId});
            builder.Property(r => r.Rating).HasColumnType("decimal(3, 2)");
            builder.Property(r => r.ReviewText);
            builder.HasOne(r => r.Movie).WithMany(m => m.Reviews).HasForeignKey(r => r.MovieId);
            builder.HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UserId);

        }

        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mc => new {mc.CrewId, mc.MovieId});
            builder.Property(mc => mc.Department).HasMaxLength(128);
            builder.Property(mc => mc.Job).HasMaxLength(128);
            builder.HasOne(m => m.Movie).WithMany(m => m.Crews).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(m => m.Crew).WithMany(m => m.Movies).HasForeignKey(mc => mc.CrewId);
        }

        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.Gender);
            builder.Property(c => c.TmdbUrl);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new {mc.MovieId, mc.CastId});
            builder.Property(mc => mc.Character).HasMaxLength(450);
            builder.HasOne(m => m.Movie).WithMany(m => m.Casts).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(m => m.Cast).WithMany(m => m.Movies).HasForeignKey(mc => mc.CastId);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.Gender);
            builder.Property(c => c.TmdbUrl);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new {mg.MovieId, mg.GenreId});
            builder.HasOne(m => m.Movie).WithMany(m => m.Genres).HasForeignKey(mg => mg.MovieId);
            builder.HasOne(m => m.Genre).WithMany(g => g.Movies).HasForeignKey(mg => mg.GenreId);
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // here we can model our Movie Table with our rules

            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);

            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");

            builder.Ignore(m => m.Rating);
        }

         // Func<int, int , decimal>  method(int, int)--return decimal
         // Action<int, int>  void method(int, int)


    }
}
