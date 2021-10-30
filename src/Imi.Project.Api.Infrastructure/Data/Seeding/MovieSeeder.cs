using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class MovieSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var movies = new List<Movie>
            {
                

                new Movie
                {
                    Id = 1,
                    Name = "Batman Begins",
                    Description = "When his parents are killed, billionaire playboy Bruce Wayne relocates to Asia, where he is mentored by Henri Ducard and Ra's Al Ghul in how to fight evil. When learning about the plan to wipe out evil in Gotham City by Ducard, Bruce prevents this plan from getting any further and heads back to his home. Back in his original surroundings, Bruce adopts the image of a bat to strike fear into the criminals and the corrupt as the icon known as 'Batman'. But it doesn't stay quiet for long.",
                    AverageRating = 8.2,
                    ReleaseDate = DateTime.Parse("15/06/2005"),
                    Duration = 140,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/qHhHIbNuok8",
                    Image = "/Images/MovieImg/Batman_Begins.jpg",
                },

                new Movie
                {
                    Id = 2,
                    Name = "The Dark Knight",
                    Description = "Set within a year after the events of Batman Begins (2005), Batman, Lieutenant James Gordon, and new District Attorney Harvey Dent successfully begin to round up the criminals that plague Gotham City, until a mysterious and sadistic criminal mastermind known only as The Joker appears in Gotham, creating a new wave of chaos. Batman's struggle against The Joker becomes deeply personal, forcing him to confront everything he believes and improve his technology to stop him. A love triangle develops between Bruce Wayne, Dent, and Rachel Dawes",
                    AverageRating = 9.0,
                    ReleaseDate = DateTime.Parse("14/07/2008"),
                    Duration = 152,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/TQfATDZY5Y4",
                    Image = "/Images/MovieImg/The_Dark_Knight.jpg",
                },
                new Movie
                {
                    Id = 3,
                    Name = "The Dark Knight Rises",
                    Description= "Despite his tarnished reputation after the events of The Dark Knight (2008), in which he took the rap for Dent's crimes, Batman feels compelled to intervene to assist the city and its Police force, which is struggling to cope with Bane's plans to destroy the city.",
                    AverageRating = 8.4,
                    ReleaseDate = DateTime.Parse("20/07/2012"),
                    Duration = 164,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/g8evyE9TuYk",
                    Image = "/Images/MovieImg/The_Dark_Knight_Rises.jpg",
                },
                new Movie
                {
                    Id = 4,
                    Name = "The Prestige",
                    Description="After a tragic accident, two stage magicians in 1890s London engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.",
                    AverageRating = 8.5,
                    ReleaseDate = DateTime.Parse("22/10/2006"),
                    Duration = 130,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/ObGVA1WOqyE",
                    Image = "/Images/MovieImg/The_Prestige.jpg",
                },                
                new Movie
                {
                    Id = 5,
                    Name = "Django Unchained",
                    Description="With the help of a German bounty-hunter, a freed slave sets out to rescue his wife from a brutal plantation-owner in Mississippi.",
                    AverageRating = 8.4,
                    ReleaseDate = DateTime.Parse("30/12/2012"),
                    Duration = 165,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/0fUCuvNlOCg",
                    Image = "/Images/MovieImg/Django_Unchained.jpg",
                },
                new Movie
                {
                    Id = 6,
                    Name = "Inglourious Basterds",
                    Description="In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.",
                    AverageRating = 8.3,
                    ReleaseDate = DateTime.Parse("23/08/2009"),
                    Duration = 153,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/KnrRy6kSFF0",
                    Image = "/Images/MovieImg/Inglourious_Basterds.jpg",
                },
                new Movie
                {
                    Id = 7,
                    Name = "X-Men: First Class",
                    Description="In the 1960s, superpowered humans Charles Xavier and Erik Lensherr work together to find others like them, but Erik's vengeful pursuit of an ambitious mutant who ruined his life causes a schism to divide them.",
                    AverageRating = 7.7,
                    ReleaseDate = DateTime.Parse("05/06/2011"),
                    Duration = 131,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/zp4rIZnQobE",
                    Image = "/Images/MovieImg/X-Men_First_Class.jpg",
                },
                new Movie
                {
                    Id = 8,
                    Name = "X-Men: Apocalypse",
                    Description="In the 1980s the X-Men must defeat an ancient all-powerful mutant, En Sabah Nur, who intends to thrive through bringing destruction to the world.",
                    AverageRating = 6.9,
                    ReleaseDate = DateTime.Parse("29/05/2016"),
                    Duration = 144,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/COvnHv42T-A",
                    Image = "/Images/MovieImg/X-Men_Apocalypse.jpg",
                },
                new Movie
                {
                    Id = 9,
                    Name = "X-Men: Dark Phoenix",
                    Description="Jean Grey begins to develop incredible powers that corrupt and turn her into a Dark Phoenix, causing the X-Men to decide if her life is worth more than all of humanity.",
                    AverageRating = 5.7,
                    ReleaseDate = DateTime.Parse("06/06/2019"),
                    Duration = 113,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/1-q8C_c-nlM",
                    Image = "/Images/MovieImg/X-Men_Dark_Phoenix.jpg",
                },
                new Movie
                {
                    Id = 10,
                    Name = "The Avengers",
                    Description="Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.",
                    AverageRating = 8.0,
                    ReleaseDate = DateTime.Parse("06/05/2012"),
                    Duration = 143,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/eOrNdBpGMv8",
                    Image = "/Images/MovieImg/The_Avengers.jpg",
                },
                new Movie
                {
                    Id = 11,
                    Name = "Avengers: Age of Ultron",
                    Description="When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.",
                    AverageRating = 7.3,
                    ReleaseDate = DateTime.Parse("03/05/2015"),
                    Duration = 141,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/tmeOjFno6Do",
                    Image = "/Images/MovieImg/Avengers_Age_of_Ultron.jpg",
                },
                new Movie
                {
                    Id = 12,
                    Name = "Avengers: Infinity War",
                    Description="The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
                    AverageRating = 8.4,
                    ReleaseDate = DateTime.Parse("29/04/2018"),
                    Duration = 149,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/6ZfuNTqbHE8",
                    Image = "/Images/MovieImg/Avengers_Infinity_War.jpg",
                },
                new Movie
                {
                    Id = 13,
                    Name = "Avengers: Endgame",
                    Description="After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                    AverageRating = 8.4,
                    ReleaseDate = DateTime.Parse("24/04/2019"),
                    Duration = 181,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/TcMBFSGVi1c",
                    Image = "/Images/MovieImg/Avengers_Endgame.jpg",
                },
                new Movie
                {
                    Id = 14,
                    Name = "Captain America: Civil War",
                    Description="Political involvement in the Avengers' affairs causes a rift between Captain America and Iron Man.",
                    AverageRating = 7.8,
                    ReleaseDate = DateTime.Parse("08/05/2016"),
                    Duration = 147,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/dKrVegVI0Us",
                    Image = "/Images/MovieImg/Captain_America_Civil_War.jpg",
                },
                new Movie
                {
                    Id = 15,
                    Name = "Now You See Me",
                    Description="An F.B.I. Agent and an Interpol Detective track a team of illusionists who pull off bank heists during their performances, and reward their audiences with the money.",
                    AverageRating = 7.2,
                    ReleaseDate = DateTime.Parse("02/06/2013"),
                    Duration = 115,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/KzJNYYkkhzc",
                    Image = "/Images/MovieImg/Now_You_See_Me.jpg",
                },
                new Movie
                {
                    Id = 16,
                    Name = "Now You See Me 2",
                    Description="The Four Horsemen resurface, and are forcibly recruited by a tech genius to pull off their most impossible heist yet.",
                    AverageRating = 6.5,
                    ReleaseDate = DateTime.Parse("12/06/2016"),
                    Duration = 129,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/4I8rVcSQbic",
                    Image = "/Images/MovieImg/Now_You_See_Me_2.jpg",
                },
                new Movie
                {
                    Id = 17,
                    Name = "Inception",
                    Description="A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                    AverageRating = 8.8,
                    ReleaseDate = DateTime.Parse("18/07/2010"),
                    Duration = 148,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/YoHD9XEInc0",
                    Image = "/Images/MovieImg/Inception.jpg",
                },
                new Movie
                {
                    Id = 18,
                    Name = "The Wolf of Wall Street",
                    Description="Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
                    AverageRating = 8.2,
                    ReleaseDate = DateTime.Parse("29/12/2013"),
                    Duration = 180,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/iszwuX1AK6A",
                    Image = "/Images/MovieImg/The_Wolf_of_Wall_Street.jpg",
                },
                new Movie
                {
                    Id = 19,
                    Name = "Once Upon a Time... in Hollywood",
                    Description="A faded television actor and his stunt double strive to achieve fame and success in the final years of Hollywood's Golden Age in 1969 Los Angeles.",
                    AverageRating = 7.6,
                    ReleaseDate = DateTime.Parse("28/07/2019"),
                    Duration = 161,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/ELeMaP8EPAA",
                    Image = "/Images/MovieImg/Once_Upon_a_Time_in_Hollywood.jpg",
                },
                new Movie
                {
                    Id = 20,
                    Name = "The Revenant",
                    Description = "A frontiersman on a fur trading expedition in the 1820s fights for survival after being mauled by a bear and left for dead by members of his own hunting team.",
                    AverageRating = 8.0,
                    ReleaseDate = DateTime.Parse("27/12/2015"),
                    Duration = 156,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/LoebZZ8K5N0",
                    Image = "/Images/MovieImg/The_Revenant.jpg",
                },
                new Movie
                {
                    Id = 21,
                    Name = "The Great Gatsby",
                    Description = "A writer and wall street trader, Nick, finds himself drawn to the past and lifestyle of his millionaire neighbor, Jay Gatsby.",
                    AverageRating = 7.2,
                    ReleaseDate = DateTime.Parse("12/05/2013"),
                    Duration = 143,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/sN183rJltNM",
                    Image = "/Images/MovieImg/The_Great_Gatsby.jpg",
                },
                new Movie
                {
                    Id = 22,
                    Name = "Shutter Island",
                    Description = "In 1954, a U.S. Marshal investigates the disappearance of a murderer who escaped from a hospital for the criminally insane.",
                    AverageRating = 8.2,
                    ReleaseDate = DateTime.Parse("21/02/2010"),
                    Duration = 138,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/5iaYLCiq5RM",
                    Image = "/Images/MovieImg/Shutter_Island.jpg",
                },                
                new Movie
                {
                    Id = 23,
                    Name = "Troy",
                    Description = "An adaptation of Homer's great epic, the film follows the assault on Troy by the united Greek forces and chronicles the fates of the men involved.",
                    AverageRating = 7.3,
                    ReleaseDate = DateTime.Parse("16/05/2004"),
                    Duration = 163,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/znTLzRJimeY",
                    Image = "/Images/MovieImg/Troy.jpg",
                },
                new Movie
                {
                    Id = 24,
                    Name = "Fury",
                    Description = "A grizzled tank commander makes tough decisions as he and his crew fight their way across Germany in April, 1945.",
                    AverageRating = 7.6,
                    ReleaseDate = DateTime.Parse("19/10/2014"),
                    Duration = 134,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/DNHuK1rteF4",
                    Image = "/Images/MovieImg/Fury.jpg",
                },
                new Movie
                {
                    Id = 25,
                    Name = "Transformers",
                    Description = "An ancient struggle between two Cybertronian races, the heroic Autobots and the evil Decepticons, comes to Earth, with a clue to the ultimate power held by a teenager.",
                    AverageRating = 7.0,
                    ReleaseDate = DateTime.Parse("08/07/2007"),
                    Duration = 144,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/dxQxgAfNzyE",
                    Image = "/Images/MovieImg/Transformers.jpg",
                },
                new Movie
                {
                    Id = 26,
                    Name = "Transformers: Revenge of the Fallen",
                    Description = "Sam Witwicky leaves the Autobots behind for a normal life. But when his mind is filled with cryptic symbols, the Decepticons target him and he is dragged back into the Transformers' war.",
                    AverageRating = 6.0,
                    ReleaseDate = DateTime.Parse("28/06/2009"),
                    Duration = 149,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/fnXzKwUgDhg",
                    Image = "/Images/MovieImg/Transformers_Revenge_of_the_Fallen.jpg",
                },
                new Movie
                {
                    Id = 27,
                    Name = "Transformers: Dark of the Moon",
                    Description = "The Autobots learn of a Cybertronian spacecraft hidden on the moon, and race against the Decepticons to reach it and to learn its secrets.",
                    AverageRating = 6.2,
                    ReleaseDate = DateTime.Parse("03/07/2011"),
                    Duration = 154,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/bTIrEZM-cFE",
                    Image = "/Images/MovieImg/Transformers_Dark_of_the_Moon.jpg",
                },
                new Movie
                {
                    Id = 28,
                    Name = "Pirates of the Caribbean: The Curse of the Black Pearl",
                    Description = "Blacksmith Will Turner teams up with eccentric pirate Captain Jack Sparrow to save his love, the governor's daughter, from Jack's former pirate allies, who are now undead.",
                    AverageRating = 8.0,
                    ReleaseDate = DateTime.Parse("13/07/2003"),
                    Duration = 143,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/-9HT0l9HV4",
                    Image = "/Images/MovieImg/Pirates_of_the_Caribbean_The_Curse_of_the_Black_Pearl.jpg",
                },
                new Movie
                {
                    Id = 29,
                    Name = "Pirates of the Caribbean: Dead Man's Chest",
                    Description = "Jack Sparrow races to recover the heart of Davy Jones to avoid enslaving his soul to Jones' service, as other friends and foes seek the heart for their own agenda as well.",
                    AverageRating = 7.3,
                    ReleaseDate = DateTime.Parse("09/07/2006"),
                    Duration = 151,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/ozk0-RHXtFw",
                    Image = "/Images/MovieImg/Pirates_of_the_Caribbean_Dead_Man's_Chest.jpg",
                },
                new Movie
                {
                    Id = 30,
                    Name = "Pirates of the Caribbean: At World's End",
                    Description = "Captain Barbossa, Will Turner and Elizabeth Swann must sail off the edge of the map, navigate treachery and betrayal, find Jack Sparrow, and make their final alliances for one last decisive battle.",
                    AverageRating = 7.1,
                    ReleaseDate = DateTime.Parse("27/05/2007"),
                    Duration = 169,
                    EmbeddedTrailerUrl = "https://www.youtube.com/embed/0op_XllRaAw",
                    Image = "/Images/MovieImg/Pirates_of_the_Caribbean_At_World's_End.jpg",
                },
                //new Movie
                //{
                //    Id = 0,
                //    Name = "",
                //    Description = "",
                //    AverageRating = 0,
                //    ReleaseDate = DateTime.Parse(""),
                //    Duration = 0,
                //    EmbeddedTrailerUrl = "",
                //    Image = "/Images/MovieImg/",
                //},
            };
            //for (int i = 0; i < movies.Count; i++)
            //{
            //    movies[i].Id = i + 1;
            //}
            modelBuilder.Entity<Movie>().HasData(movies);
        }

    }
}
