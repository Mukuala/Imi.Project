using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Imi.Project.Mobile.Core.Services.Mocking
{
    public class MockMovieService
    {
        public static List<Movie> Movies = new List<Movie>
        {
                new Movie
                {
                    Id = 1,
                    Name = "Batman Begins",
                    Description = "When his parents are killed, billionaire playboy Bruce Wayne relocates to Asia, where he is mentored by Henri Ducard and Ra's Al Ghul in how to fight evil. When learning about the plan to wipe out evil in Gotham City by Ducard, Bruce prevents this plan from getting any further and heads back to his home. Back in his original surroundings, Bruce adopts the image of a bat to strike fear into the criminals and the corrupt as the icon known as 'Batman'. But it doesn't stay quiet for long.",
                    AverageRating = 8.2,
                    ReleaseDate = DateTime.ParseExact( "15/06/2005" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
        //DateTime.Parse("15/06/2005"),
                    Duration = 140,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/qHhHIbNuok8",
                    Image ="Batman_Begins.jpg",
                    Genres =  new List<Genre>{
                                new Genre{ Id = 1, Name = "Action" },
                                new Genre{ Id = 2, Name = "Adventure"},
                                new Genre{ Id = 3, Name = "Crime"},
                             },
                    Actors= new List<Actor>{
                               new Actor{
                                    Id = 1,
                                    Name = "Christian Bale",
                                    Biography = "Christian Charles Philip Bale was born in Pembrokeshire, Wales, UK on January 30, 1974, to English parents Jennifer Jenny (James) and David Bale. His mother was a circus performer and his father, who was born in South Africa, was a commercial pilot. The family lived in different countries throughout Bale's childhood, including England, Portugal, and the United States. Bale acknowledges the constant change was one of the influences on his career choice.",
                                    Image = "Christian_Bale.jpg",
                                    DateOfBirth= DateTime.ParseExact( "30/01/1974" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                         },
                             }

                },

                new Movie
                {
                    Id = 2,
                    Name = "The Dark Knight",
                    Description = "Set within a year after the events of Batman Begins (2005), Batman, Lieutenant James Gordon, and new District Attorney Harvey Dent successfully begin to round up the criminals that plague Gotham City, until a mysterious and sadistic criminal mastermind known only as The Joker appears in Gotham, creating a new wave of chaos. Batman's struggle against The Joker becomes deeply personal, forcing him to confront everything he believes and improve his technology to stop him. A love triangle develops between Bruce Wayne, Dent, and Rachel Dawes",
                    AverageRating = 9.0,
                    ReleaseDate = DateTime.ParseExact( "14/07/2008" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //DateTime.Parse("14/07/2008"),
                    Duration = 152,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/TQfATDZY5Y4",
                    Image = "The_Dark_Knight.jpg",
                },
                new Movie
                {
                    Id = 3,
                    Name = "The Dark Knight Rises",
                    Description= "Despite his tarnished reputation after the events of The Dark Knight (2008), in which he took the rap for Dent's crimes, Batman feels compelled to intervene to assist the city and its Police force, which is struggling to cope with Bane's plans to destroy the city.",
                    AverageRating = 8.4,
                    ReleaseDate = DateTime.ParseExact( "20/07/2012" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //DateTime.Parse("20/07/2012"),
                    Duration = 164,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/g8evyE9TuYk",
                    Image = "The_Dark_Knight_Rises.jpg",
                },
                new Movie
                {
                    Id = 4,
                    Name = "Batman Begins",
                    Description = "When his parents are killed, billionaire playboy Bruce Wayne relocates to Asia, where he is mentored by Henri Ducard and Ra's Al Ghul in how to fight evil. When learning about the plan to wipe out evil in Gotham City by Ducard, Bruce prevents this plan from getting any further and heads back to his home. Back in his original surroundings, Bruce adopts the image of a bat to strike fear into the criminals and the corrupt as the icon known as 'Batman'. But it doesn't stay quiet for long.",
                    AverageRating = 8.2,
                    ReleaseDate = DateTime.ParseExact( "15/06/2005" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
        //DateTime.Parse("15/06/2005"),
                    Duration = 140,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/qHhHIbNuok8",
                    Image ="Batman_Begins.jpg",

                },

                new Movie
                {
                    Id = 5,
                    Name = "The Dark Knight",
                    Description = "Set within a year after the events of Batman Begins (2005), Batman, Lieutenant James Gordon, and new District Attorney Harvey Dent successfully begin to round up the criminals that plague Gotham City, until a mysterious and sadistic criminal mastermind known only as The Joker appears in Gotham, creating a new wave of chaos. Batman's struggle against The Joker becomes deeply personal, forcing him to confront everything he believes and improve his technology to stop him. A love triangle develops between Bruce Wayne, Dent, and Rachel Dawes",
                    AverageRating = 9.0,
                    ReleaseDate = DateTime.ParseExact( "14/07/2008" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //DateTime.Parse("14/07/2008"),
                    Duration = 152,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/TQfATDZY5Y4",
                    Image = "The_Dark_Knight.jpg",
                },
                new Movie
                {
                    Id = 6,
                    Name = "The Dark Knight Rises",
                    Description= "Despite his tarnished reputation after the events of The Dark Knight (2008), in which he took the rap for Dent's crimes, Batman feels compelled to intervene to assist the city and its Police force, which is struggling to cope with Bane's plans to destroy the city.",
                    AverageRating = 8.4,
                    ReleaseDate = DateTime.ParseExact( "20/07/2012" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //DateTime.Parse("20/07/2012"),
                    Duration = 164,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/g8evyE9TuYk",
                    Image = "The_Dark_Knight_Rises.jpg",
                },
                new Movie
                {
                    Id = 7,
                    Name = "The Dark Knight Rises",
                    Description= "Despite his tarnished reputation after the events of The Dark Knight (2008), in which he took the rap for Dent's crimes, Batman feels compelled to intervene to assist the city and its Police force, which is struggling to cope with Bane's plans to destroy the city.",
                    AverageRating = 8.4,
                    ReleaseDate = DateTime.ParseExact( "20/07/2012" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //DateTime.Parse("20/07/2012"),
                    Duration = 164,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/g8evyE9TuYk",
                    Image = "The_Dark_Knight_Rises.jpg",
                },
                new Movie
                {
                    Id = 8,
                    Name = "Batman Begins",
                    Description = "When his parents are killed, billionaire playboy Bruce Wayne relocates to Asia, where he is mentored by Henri Ducard and Ra's Al Ghul in how to fight evil. When learning about the plan to wipe out evil in Gotham City by Ducard, Bruce prevents this plan from getting any further and heads back to his home. Back in his original surroundings, Bruce adopts the image of a bat to strike fear into the criminals and the corrupt as the icon known as 'Batman'. But it doesn't stay quiet for long.",
                    AverageRating = 8.2,
                    ReleaseDate = DateTime.ParseExact( "15/06/2005" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
        //DateTime.Parse("15/06/2005"),
                    Duration = 140,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/qHhHIbNuok8",
                    Image ="Batman_Begins.jpg",

                },

                new Movie
                {
                    Id = 9,
                    Name = "The Dark Knight",
                    Description = "Set within a year after the events of Batman Begins (2005), Batman, Lieutenant James Gordon, and new District Attorney Harvey Dent successfully begin to round up the criminals that plague Gotham City, until a mysterious and sadistic criminal mastermind known only as The Joker appears in Gotham, creating a new wave of chaos. Batman's struggle against The Joker becomes deeply personal, forcing him to confront everything he believes and improve his technology to stop him. A love triangle develops between Bruce Wayne, Dent, and Rachel Dawes",
                    AverageRating = 9.0,
                    ReleaseDate = DateTime.ParseExact( "14/07/2008" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //DateTime.Parse("14/07/2008"),
                    Duration = 152,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/TQfATDZY5Y4",
                    Image = "The_Dark_Knight.jpg",
                },
                new Movie
                {
                    Id = 10,
                    Name = "The Dark Knight Rises",
                    Description= "Despite his tarnished reputation after the events of The Dark Knight (2008), in which he took the rap for Dent's crimes, Batman feels compelled to intervene to assist the city and its Police force, which is struggling to cope with Bane's plans to destroy the city.",
                    AverageRating = 8.4,
                    ReleaseDate = DateTime.ParseExact( "20/07/2012" , "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //DateTime.Parse("20/07/2012"),
                    Duration = 164,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/g8evyE9TuYk",
                    Image = "The_Dark_Knight_Rises.jpg",
                },
        };
    }
}
