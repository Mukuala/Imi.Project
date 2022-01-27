using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<MovieGenre>()
                .HasOne<Genre>(mg => mg.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(mg => mg.GenreId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne<Movie>(mg => mg.Movie)
                .WithMany(m => m.Genres)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });
            modelBuilder.Entity<MovieActor>()
                .HasOne<Actor>(ma => ma.Actor)
                .WithMany(a => a.Movies)
                .HasForeignKey(ma => ma.ActorId);
            modelBuilder.Entity<MovieActor>()
                .HasOne<Movie>(ma => ma.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<Favorite>()
                .HasOne<ApplicationUser>(f => f.ApplicationUser)
                .WithMany(a => a.FavoriteMovies)
                .HasForeignKey(f => f.ApplicationUserId);
            modelBuilder.Entity<Favorite>()
                .HasOne<Movie>(f => f.Movie)
                .WithMany(m => m.UsersFavorite)
                .HasForeignKey(f => f.MovieId);

            modelBuilder.Entity<Watchlist>()
                .HasOne<ApplicationUser>(w => w.ApplicationUser)
                .WithMany(a => a.WatchlistMovies)
                .HasForeignKey(w => w.ApplicationUserId);
            modelBuilder.Entity<Watchlist>()
                .HasOne<Movie>(w => w.Movie)
                .WithMany(m => m.UsersWatchlist)
                .HasForeignKey(w => w.MovieId);

            UserSeeder.Seed(modelBuilder);
            GenreSeeder.Seed(modelBuilder);
            ActorSeeder.Seed(modelBuilder);
            MovieSeeder.Seed(modelBuilder);
            FavoriteSeeder.Seed(modelBuilder);
            WatchlistSeeder.Seed(modelBuilder);
            MovieActorSeeder.Seed(modelBuilder);
            MovieGenreSeeder.Seed(modelBuilder);
        }

    }
}
