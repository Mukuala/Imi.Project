using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieGenre>()
                .HasOne<Genre>(mg => mg.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(mg => mg.GenreId);
            modelBuilder.Entity<MovieActor>()
                .HasOne<Actor>(ma => ma.Actor)
                .WithMany(a => a.Movies)
                .HasForeignKey(ma => ma.ActorId);
            modelBuilder.Entity<Favorite>()
                .HasOne<ApplicationUser>(f => f.ApplicationUser)
                .WithMany(a => a.FavoriteMovies)
                .HasForeignKey(f => f.ApplicationUserId);
            modelBuilder.Entity<Watchlist>()
                .HasOne<ApplicationUser>(f => f.ApplicationUser)
                .WithMany(a => a.WatchlistMovies)
                .HasForeignKey(f => f.ApplicationUserId);

        }

    }
}
