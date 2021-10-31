using Imi.Project.Mobile.Core.Services.Mocking;
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
    public partial class AddMoviePage : ContentPage
    {
        public AddMoviePage()
        {
            InitializeComponent();
            GenrePicker.ItemsSource = MockGenreService.Genres;
            ActorPicker.ItemsSource = MockActorService.Actors;
        }
    }
}