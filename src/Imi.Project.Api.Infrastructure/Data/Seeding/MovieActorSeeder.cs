using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class MovieActorSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var list = new List<MovieActor>
            {
                
                //Batman Begins
                new MovieActor { MovieId = 1, ActorId = 1 },
                //The Dark Knight
                new MovieActor { MovieId = 2, ActorId = 1 },
                //The Dark Knight Rises
                new MovieActor { MovieId = 3, ActorId = 1 },
                new MovieActor { MovieId = 3, ActorId = 2 },
                //The Prestige
                new MovieActor { MovieId = 4, ActorId = 1 },
                new MovieActor { MovieId = 4, ActorId = 4 },
                new MovieActor { MovieId = 4, ActorId = 5 },
                //Django Unchained
                new MovieActor { MovieId = 5, ActorId = 3 },
                new MovieActor { MovieId = 5, ActorId = 8 },
                //Inglourious Basterds
                new MovieActor { MovieId = 6, ActorId = 6 },
                new MovieActor { MovieId = 6, ActorId = 7 },
                //X-Men: First Class
                new MovieActor { MovieId = 7, ActorId = 7 },
                new MovieActor { MovieId = 7, ActorId = 9 },
                new MovieActor { MovieId = 7, ActorId = 10 },
                //X-Men: Apocalypse
                new MovieActor { MovieId = 8, ActorId = 7 },
                new MovieActor { MovieId = 8, ActorId = 9 },
                new MovieActor { MovieId = 8, ActorId = 10 },
                //X-Men: Dark Phoenix                  
                new MovieActor { MovieId = 9, ActorId = 7 },
                new MovieActor { MovieId = 9, ActorId = 9 },
                new MovieActor { MovieId = 9, ActorId = 10 },
                //The Avengers
                new MovieActor { MovieId = 10, ActorId = 5 },
                new MovieActor { MovieId = 10, ActorId = 8 },
                new MovieActor { MovieId = 10, ActorId = 11 },
                new MovieActor { MovieId = 10, ActorId = 12 },
                new MovieActor { MovieId = 10, ActorId = 13 },
                new MovieActor { MovieId = 10, ActorId = 14 },
                new MovieActor { MovieId = 10, ActorId = 15 },
                //Avengers: Age of Ultron
                new MovieActor { MovieId = 11, ActorId = 5 },
                new MovieActor { MovieId = 11, ActorId = 8 },
                new MovieActor { MovieId = 11, ActorId = 11 },
                new MovieActor { MovieId = 11, ActorId = 12 },
                new MovieActor { MovieId = 11, ActorId = 13 },
                new MovieActor { MovieId = 11, ActorId = 14 },
                new MovieActor { MovieId = 11, ActorId = 15 },
                //Avengers: Infinity War
                new MovieActor { MovieId = 12, ActorId = 5 },
                new MovieActor { MovieId = 12, ActorId = 8 },
                new MovieActor { MovieId = 12, ActorId = 11 },
                new MovieActor { MovieId = 12, ActorId = 12 },
                new MovieActor { MovieId = 12, ActorId = 13 },
                new MovieActor { MovieId = 12, ActorId = 14 },
                new MovieActor { MovieId = 12, ActorId = 15 },
                //Avengers: Endgame
                new MovieActor { MovieId = 13, ActorId = 5 },
                new MovieActor { MovieId = 13, ActorId = 8 },
                new MovieActor { MovieId = 13, ActorId = 11 },
                new MovieActor { MovieId = 13, ActorId = 12 },
                new MovieActor { MovieId = 13, ActorId = 13 },
                new MovieActor { MovieId = 13, ActorId = 14 },
                new MovieActor { MovieId = 13, ActorId = 15 },
                //Captain America: Civil War
                new MovieActor { MovieId = 14, ActorId = 11 },
                new MovieActor { MovieId = 14, ActorId = 12 },
                new MovieActor { MovieId = 14, ActorId = 5 },
                //Now You See Me
                new MovieActor { MovieId = 15, ActorId = 14 },
                new MovieActor { MovieId = 15, ActorId = 16 },
                //Now You See Me 2
                new MovieActor { MovieId = 16, ActorId = 14 },
                new MovieActor { MovieId = 16, ActorId = 16 },
                //Inception
                new MovieActor { MovieId = 17, ActorId = 2 },
                new MovieActor { MovieId = 17, ActorId = 3 },
                //The Wolf of Wall Street
                new MovieActor { MovieId = 18, ActorId = 3 },
                new MovieActor { MovieId = 18, ActorId = 17 },
                //Once Upon a Time... in Hollywood
                new MovieActor { MovieId = 19, ActorId = 3 },
                new MovieActor { MovieId = 19, ActorId = 6 },
                new MovieActor { MovieId = 19, ActorId = 17 },
                //The Revenant
                new MovieActor { MovieId = 20, ActorId = 3 },
                new MovieActor { MovieId = 20, ActorId = 2 },
                //The Great Gatsby
                new MovieActor { MovieId = 21, ActorId = 3 },
                //Shutter Island
                new MovieActor { MovieId = 22, ActorId = 3 },
                new MovieActor { MovieId = 22, ActorId = 14 },
                //Troy
                new MovieActor { MovieId = 23, ActorId = 6 },
                new MovieActor { MovieId = 23, ActorId = 21 },
                //Fury
                new MovieActor { MovieId = 24, ActorId = 6 },
                new MovieActor { MovieId = 24, ActorId = 18 },
                //Transformers
                new MovieActor { MovieId = 25, ActorId = 18 },
                new MovieActor { MovieId = 25, ActorId = 19 },
                //Transformers: Revenge of the Fallen
                new MovieActor { MovieId = 26, ActorId = 18 },
                new MovieActor { MovieId = 26, ActorId = 19 },
                //Transformers: Dark of the Moon
                new MovieActor { MovieId = 27, ActorId = 18 },
                //Pirates of the Caribbean: The Curse of the Black Pearl
                new MovieActor { MovieId = 28, ActorId = 20 },
                new MovieActor { MovieId = 28, ActorId = 21 },
                new MovieActor { MovieId = 28, ActorId = 22 },
                //Pirates of the Caribbean: Dead Man's Chest
                new MovieActor { MovieId = 29, ActorId = 20 },
                new MovieActor { MovieId = 29, ActorId = 21 },
                new MovieActor { MovieId = 29, ActorId = 22 },
                //Pirates of the Caribbean: At World's End
                new MovieActor { MovieId = 30, ActorId = 20 },
                new MovieActor { MovieId = 30, ActorId = 21 },
                new MovieActor { MovieId = 30, ActorId = 22 },

                //new MovieActor { MovieId = 0, ActorId = 0 },
                //new MovieActor { Id = 0, MovieId = 0, ActorId = 0 },
            };
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Id = i + 1;
            }

            modelBuilder.Entity<MovieActor>().HasData(list);                                                 
        }

    }
}
