using DLToolkit.Forms.Controls;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Services.Mocking;
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
    public partial class MainPageDetail : ContentPage
    {
        public MainPageDetail()
        {
            InitializeComponent();
            MoviesList.ItemsSource = MockMovieService.Movies;
        }

        private async void MoviesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var movies = e.CurrentSelection;
            ((CollectionView)sender).SelectedItem = null;
            for (int i = 0; i < movies.Count; i++)
            {
                var movie = movies[i] as Movie;
                await Navigation.PushAsync(new MovieDetailPage(movie));
            }
        }
    }
}