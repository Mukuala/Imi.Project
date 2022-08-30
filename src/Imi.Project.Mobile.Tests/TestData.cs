using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Tests
{
    public class TestData
    {
        public static MovieResponseDto[] TestMovies => new[]{
            new MovieResponseDto
            {
                 Id=1,
                 AverageRating=1,
                 Description="testDescription",
                 Duration=200,
                 Name="TestMovieName",
                 ReleaseDate=DateTime.Now,
                 EmbeddedTrailerUrl = "https://www.youtube.com/embed/qHhHIbNuok8",
                 Image = "/Images/MovieImg/Batman_Begins.jpg",
            },
            new MovieResponseDto
            {
                 Id=2,
                 AverageRating=2,
                 Description="testDescription2",
                 Duration=200,
                 Name="TestFilm",
                 ReleaseDate=DateTime.Now,
                 EmbeddedTrailerUrl = "https://www.youtube.com/embed/qHhHIbNuok8",
                 Image = "/Images/MovieImg/Batman_Begins.jpg",
            },
            new MovieResponseDto
            {
                 Id=3,
                 AverageRating=3,
                 Description="testDescription3",
                 Duration=200,
                 Name="TestMovieName2",
                 ReleaseDate=DateTime.Now,
                 EmbeddedTrailerUrl = "https://www.youtube.com/embed/qHhHIbNuok8",
                 Image = "/Images/MovieImg/Batman_Begins.jpg",
            },

        };
    }
}
