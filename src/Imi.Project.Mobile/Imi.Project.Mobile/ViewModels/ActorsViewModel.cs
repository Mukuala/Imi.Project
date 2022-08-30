using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class ActorsViewModel : FreshBasePageModel
    {

        private readonly IApiService<ActorResponseDto, ActorRequestDto> _actorApiService;
        public ActorsViewModel(IApiService<ActorResponseDto, ActorRequestDto> actorApiService)
        {
            _actorApiService = actorApiService;
        }
        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await FillActors();
        }
        public override async void Init(object initData)
        {
            base.Init(initData);
            await FillActors();
        }

        private async void NavigateToActorDetailPage(int actorId)
        {
            await CoreMethods.PushPageModel<ActorDetailViewModel>(actorId);
        }

        private async Task Delete(int id)
        {
            var name = Actors.FirstOrDefault(g => g.Id == id).Name;
            var alert = await CoreMethods.DisplayAlert("Delete", $"Are you sure you want to delete {name}?", "Yes", "No");
            if (alert)
            {
                await _actorApiService.DeleteCallApi(id.ToString(), Preferences.Get("JwtToken", null));
            }
        }

        private async Task Search()
        {
            var apiActors = await _actorApiService.GetAllAsync(SearchText);
            if (apiActors != null)
                Actors = new ObservableCollection<ActorResponseDto>(apiActors);
            else
                Actors = null;
        }

        private async Task FillActors()
        {
            IsBusy = true;
            try
            {
                Actors = null;
                var apiActors = await _actorApiService.GetAllAsync();
                Actors = new ObservableCollection<ActorResponseDto>(apiActors);
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #region Properties
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                RaisePropertyChanged(nameof(searchText));
            }
        }


        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        private ObservableCollection<ActorResponseDto> actors;
        public ObservableCollection<ActorResponseDto> Actors
        {
            get { return actors; }
            set
            {
                actors = value;
                RaisePropertyChanged(nameof(Actors));
            }
        }

        private ActorResponseDto selectedActor;
        public ActorResponseDto SelectedActor
        {
            get
            {
                return selectedActor;
            }
            set
            {
                selectedActor = value;
                if (SelectedActor != null)
                    NavigateToActorDetailPage(SelectedActor.Id);
                RaisePropertyChanged(nameof(SelectedActor));
            }
        }

        #endregion

        #region Command
        public ICommand SearchItem => new Command(
    async () =>
    {
        await Search();
    });

        public ICommand RefreshCommand => new Command(
    async () =>
    {
        await FillActors();
    });

        public ICommand DeleteCommand => new Command<int>(
    async (int id) =>
    {
        await Delete(id);
        await FillActors();
    });

        public ICommand NavigateToEditActorPage => new Command<int>(
    async (int id) =>
    {
        //push only 1 page if user accidentally clicks multiple times
        var amount = CurrentPage.Navigation.NavigationStack.Where(x => x is AddActorPage).Count();
        if (amount < 1)
        {
            await CoreMethods.PushPageModel<AddActorViewModel>(id);
        }
    });

        public ICommand NavigateToAddActorPage => new Command(
    async () =>
    {
        //push only 1 page if user accidentally clicks multiple times
        var amount = CurrentPage.Navigation.NavigationStack.Where(x => x is AddActorPage).Count();
        if (amount < 1)
        {
            await CoreMethods.PushPageModel<AddActorViewModel>();
        }
    });
        #endregion
    }
}
