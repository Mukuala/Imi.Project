using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class NavigationViewModel: FreshBasePageModel
    {
        #region Commands
        public ICommand OpenActorsPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorsViewModel>();
            });

        public ICommand OpenGenresPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<GenresViewModel>();
            });

        public ICommand OpenUsersPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorsViewModel>();
            });

        public ICommand OpenAddMoviePage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorsViewModel>();
            });

        public ICommand OpenAddActorPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorsViewModel>();
            });

        public ICommand OpenAddGenrePage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorsViewModel>();
            });

        public ICommand OpenAddUserPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorsViewModel>();
            });

        public ICommand OpenWatchlistPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorsViewModel>();
            });

        public ICommand OpenFavoritePage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorsViewModel>();
            });

        public ICommand OpenProfilePage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorsViewModel>();
            });
        #endregion
    }
}
