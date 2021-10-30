using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class MovieGenreSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var list = new List<MovieGenre>
            {
                                //Batman Begins
                new MovieGenre {  MovieId = 1, GenreId = 1 },
                new MovieGenre {  MovieId = 1, GenreId = 2 },
                //The Dark Knight
                new MovieGenre {  MovieId = 2, GenreId = 1 },
                new MovieGenre {  MovieId = 2, GenreId = 3 },
                new MovieGenre {  MovieId = 2, GenreId = 4 },
                //The Dark Knight Rises
                new MovieGenre {  MovieId = 3, GenreId = 1 },
                new MovieGenre {  MovieId = 3, GenreId = 3 },
                //The Prestige
                new MovieGenre { MovieId = 4, GenreId = 4 },
                new MovieGenre { MovieId = 4, GenreId = 5 },
                new MovieGenre { MovieId = 4, GenreId = 6 },
                //Django Unchained
                new MovieGenre { MovieId = 5, GenreId = 4 },
                new MovieGenre { MovieId = 5, GenreId = 7 },
                //Inglourious Basterds
                new MovieGenre { MovieId = 6, GenreId = 2 },
                new MovieGenre { MovieId = 6, GenreId = 4},
                new MovieGenre { MovieId = 6, GenreId = 9 },
                //X-Men: First Class
                new MovieGenre { MovieId = 7, GenreId = 1 },
                new MovieGenre { MovieId = 7, GenreId = 2 },
                new MovieGenre { MovieId = 7, GenreId = 6 },
                //X-Men: Apocalypse
                new MovieGenre { MovieId = 8, GenreId = 1 },
                new MovieGenre { MovieId = 8, GenreId = 2 },
                new MovieGenre { MovieId = 8, GenreId = 6 },
                //X-Men: Dark Phoenix
                new MovieGenre { MovieId = 9, GenreId = 1 },
                new MovieGenre { MovieId = 9, GenreId = 2 },
                new MovieGenre { MovieId = 9, GenreId = 6 },
                //The Avengers
                new MovieGenre { MovieId = 10, GenreId = 1 },
                new MovieGenre { MovieId = 10, GenreId = 2 },
                new MovieGenre { MovieId = 10, GenreId = 6 },
                //Avengers: Age of Ultron
                new MovieGenre { MovieId = 11, GenreId = 1 },
                new MovieGenre { MovieId = 11, GenreId = 2 },
                new MovieGenre { MovieId = 11, GenreId = 6 },
                //Avengers: Infinity War
                new MovieGenre { MovieId = 12, GenreId = 1 },
                new MovieGenre { MovieId = 12, GenreId = 2 },
                new MovieGenre { MovieId = 12, GenreId = 6 },
                //Avengers: Endgame
                new MovieGenre { MovieId = 13, GenreId = 1 },
                new MovieGenre { MovieId = 13, GenreId = 2 },
                new MovieGenre { MovieId = 13, GenreId = 4 },
                //Captain America: Civil War
                new MovieGenre { MovieId = 14, GenreId = 1 },
                new MovieGenre { MovieId = 14, GenreId = 2 },
                new MovieGenre { MovieId = 14, GenreId = 6 },
                //Now You See Me
                new MovieGenre { MovieId = 15, GenreId = 3 },
                new MovieGenre { MovieId = 15, GenreId = 5 },
                new MovieGenre { MovieId = 15, GenreId = 11 },
                //Now You See Me 2
                new MovieGenre { MovieId = 16, GenreId = 1 },
                new MovieGenre { MovieId = 16, GenreId = 2 },
                new MovieGenre { MovieId = 16, GenreId = 10 },
                //Inception
                new MovieGenre { MovieId = 17, GenreId = 1 },
                new MovieGenre { MovieId = 17, GenreId = 2 },
                new MovieGenre { MovieId = 17, GenreId = 6 },
                //The Wolf of Wall Street
                new MovieGenre { MovieId = 18, GenreId = 3 },
                new MovieGenre { MovieId = 18, GenreId = 10 },
                new MovieGenre { MovieId = 18, GenreId = 12 },
                //Once Upon a Time... in Hollywood
                new MovieGenre { MovieId = 19, GenreId = 4 },
                new MovieGenre { MovieId = 19, GenreId = 10 },
                //The Revenant
                new MovieGenre { MovieId = 20, GenreId = 1 },
                new MovieGenre { MovieId = 20, GenreId = 2 },
                new MovieGenre { MovieId = 20, GenreId = 4 },
                //The Great Gatsby
                new MovieGenre { MovieId = 21, GenreId = 4 },
                new MovieGenre { MovieId = 21, GenreId = 13 },
                //Shutter Island
                new MovieGenre { MovieId = 22, GenreId = 5 },
                new MovieGenre { MovieId = 22, GenreId = 11 },
                //Troy
                new MovieGenre { MovieId = 23, GenreId = 4 },
                new MovieGenre { MovieId = 23, GenreId = 14 },
                //Fury
                new MovieGenre { MovieId = 24, GenreId = 1 },
                new MovieGenre { MovieId = 24, GenreId = 4 },
                new MovieGenre { MovieId = 24, GenreId = 9 },
                //Transformers
                new MovieGenre { MovieId = 25, GenreId = 1 },
                new MovieGenre { MovieId = 25, GenreId = 2 },
                new MovieGenre { MovieId = 25, GenreId = 6 },
                //Transformers: Revenge of the Fallen
                new MovieGenre { MovieId = 26, GenreId = 1 },
                new MovieGenre { MovieId = 26, GenreId = 2 },
                new MovieGenre { MovieId = 26, GenreId = 6 },
                //Transformers: Dark of the Moon
                new MovieGenre { MovieId = 27, GenreId = 1 },
                new MovieGenre { MovieId = 27, GenreId = 2 },
                new MovieGenre { MovieId = 27, GenreId = 6 },
                //Pirates of the Caribbean: The Curse of the Black Pearl
                new MovieGenre { MovieId = 28, GenreId = 1 },
                new MovieGenre { MovieId = 28, GenreId = 2 },
                new MovieGenre { MovieId = 28, GenreId = 8 },
                //Pirates of the Caribbean: Dead Man's Chest
                new MovieGenre { MovieId = 29, GenreId = 1 },
                new MovieGenre { MovieId = 29, GenreId = 2 },
                new MovieGenre { MovieId = 29, GenreId = 8 },
                //Pirates of the Caribbean: At World's End
                new MovieGenre { MovieId = 30, GenreId = 1 },
                new MovieGenre { MovieId = 30, GenreId = 2 },
                new MovieGenre { MovieId = 30, GenreId = 8 },
               
                //new MovieGenre { MovieId = 0, GenreId = 0 },
                //new MovieGenre { MovieId = 0, GenreId = 0 },
                //new MovieGenre { MovieId = 0, GenreId = 0 },
        };
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Id = i + 1;
            }

            modelBuilder.Entity<MovieGenre>().HasData(list);
        }
    }
}
