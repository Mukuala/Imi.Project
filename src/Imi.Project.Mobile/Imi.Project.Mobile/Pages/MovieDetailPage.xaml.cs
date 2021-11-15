using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        Movie movie;
        public MovieDetailPage(Movie movie)
        {
            InitializeComponent();
            BindingContext = movie;
            this.movie = movie;
            GenresLbl.Text = AllMovieGenres();
            ActorsLbl.Text = AllMovieActors();
            ReleaseDateLbl.Text = "Release Date: " + movie.ReleaseDate.ToString("dd/MM/yyyy");
        }

        public string AllMovieGenres()
        {
            string genresString = "Genres: ";
            if (movie.Genres != null)
            {
                foreach (var g in movie.Genres)
                {
                    genresString += g.Name + ",";
                }
            }
            else
                genresString += "No genres";
            return genresString;
        }
        public string AllMovieActors()
        {
            string actorString = "Actors: ";
            if (movie.Actors != null)
            {
                foreach (var a in movie.Actors)
                {
                    actorString += a.Name + ",";
                }
            }
            else
                actorString += "No actors";
            return actorString;

        }
    }
}