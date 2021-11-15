using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageFlyout : ContentPage
    {
        public ListView ListView;

        public MainPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MainPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageFlyoutMenuItem> MenuItems { get; set; }

            public MainPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainPageFlyoutMenuItem>(new[]
                {
                    new MainPageFlyoutMenuItem {  Title = "Movies", TargetType = typeof(MainPageDetail) },
                    new MainPageFlyoutMenuItem {  Title = "My movies" },
                    new MainPageFlyoutMenuItem {  Title = "Profile" },
                    new MainPageFlyoutMenuItem {  Title = "Add Movie", TargetType= typeof(AddMoviePage) },
                    new MainPageFlyoutMenuItem {  Title = "Add Genre",TargetType=typeof(AddGenrePage)},
                    new MainPageFlyoutMenuItem {  Title = "Add Actor",TargetType=typeof(AddActorPage)},
                    new MainPageFlyoutMenuItem {  Title = "All Actors",TargetType=typeof(AllActorsPage) },
                    new MainPageFlyoutMenuItem {  Title = "All Genres",TargetType=typeof(AllGenresPage) },
                    new MainPageFlyoutMenuItem {  Title = "All Users", TargetType=typeof(AllUsersPage) },
                });
                for (int i = 0; i < MenuItems.Count; i++)
                {
                    MenuItems[i].Id = i;
                }
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}