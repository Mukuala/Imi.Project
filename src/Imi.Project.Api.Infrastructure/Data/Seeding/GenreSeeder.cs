using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class GenreSeeder
    {
        public static void Seed(ModelBuilder modelbuilder)
        {
            var genres = new List<Genre>
            {
                new Genre{ Id = 1, Name = "Action" },
                new Genre{ Id = 2, Name = "Adventure"},
                new Genre{ Id = 3, Name = "Crime"},
                new Genre{ Id = 4, Name = "Drama"},
                new Genre{ Id = 5, Name = "Mystery"},
                new Genre{ Id = 6, Name = "Sci-Fi"},
                new Genre{ Id = 7, Name = "Western"},
                new Genre{ Id = 8, Name = "Fantasy"},
                new Genre{ Id = 9, Name = "War"},
                new Genre{ Id = 10, Name = "Comedy"},
                new Genre{ Id = 11, Name = "Thriller"},
                new Genre{ Id = 12, Name = "Biography"},
                new Genre{ Id = 13, Name = "Romance"},
                new Genre{ Id = 14, Name = "History"},
               // new Genre{ Id = 0, Name = ""},
            };
            //for (int i = 0; i < genres.Count; i++)
            //{
            //    genres[i].Id = i + 1;
            //}
            modelbuilder.Entity<Genre>().HasData(genres);
        }
    }
}
