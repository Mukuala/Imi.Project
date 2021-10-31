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

namespace Imi.Project.Mobile
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
                    new MainPageFlyoutMenuItem { Id = 0, Title = "Movies", TargetType = typeof(MainPageDetail) },
                    new MainPageFlyoutMenuItem { Id = 1, Title = "My movies" },
                    new MainPageFlyoutMenuItem { Id = 2, Title = "Profile" },
                    new MainPageFlyoutMenuItem { Id = 3, Title = "Add Movie", TargetType= typeof(AddMoviePage) },
                    new MainPageFlyoutMenuItem { Id = 4, Title = "Add Genre" },
                    new MainPageFlyoutMenuItem { Id = 5, Title = "All Actors",TargetType=typeof(AllActorsPage) },
                    new MainPageFlyoutMenuItem { Id = 6, Title = "All Genres",TargetType=typeof(AllGenresPage) },
                    new MainPageFlyoutMenuItem { Id = 7, Title = "All Users", TargetType=typeof(AllUsersPage) },
                });
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