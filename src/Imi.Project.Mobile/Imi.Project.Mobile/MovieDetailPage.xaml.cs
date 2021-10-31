using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
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
            GenresLabel.Text = AllMovieGenres();
        }

        public string AllMovieGenres()
        {
            string genresString = "";
            foreach (var g in movie.Genres)
            {
                genresString += g.Name + ",";
            }
            return genresString;
        }
        public string AllMovieActors()
        {
            string actorString = "";
            foreach (var a in movie.Actors)
            {
                actorString += a.Name + ",";
            }
            return actorString;

        }
    }
}