
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMoviePage : ContentPage
    {
        public AddMoviePage()
        {
            InitializeComponent();
            //ActorCmb.DataSource = MockActorService.Actors;
            //GenreCmb.DataSource = MockGenreService.Genres;
        }
    }
}