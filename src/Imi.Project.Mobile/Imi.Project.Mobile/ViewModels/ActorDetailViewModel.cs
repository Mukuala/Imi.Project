using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Pages;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class ActorDetailViewModel : FreshBasePageModel
    {
        private readonly IApiService<ActorResponseDto, ActorRequestDto> _actorApiService;
        public ActorDetailViewModel(IApiService<ActorResponseDto, ActorRequestDto> actorApiService)
        {
            _actorApiService = actorApiService;
        }
        string actorId;

        public override async void Init(object initData)
        {
            actorId = initData.ToString();
            Actor = await _actorApiService.GetByIdAsync(actorId);
        }
        protected override async void ViewIsAppearing(object sender, System.EventArgs e)
        {
            Actor = await _actorApiService.GetByIdAsync(actorId);
        }

        private async Task Delete(int id)
        {
            var alert = await CoreMethods.DisplayAlert("Delete", $"Are you sure you want to delete {Actor.Name}?", "Yes", "No");
            if (alert)
            {
                await _actorApiService.DeleteCallApi(id.ToString(), Preferences.Get("JwtToken", null));
                await CoreMethods.PopPageModel();
            }
        }


        #region Properties

        private ActorResponseDto actor;
        public ActorResponseDto Actor
        {
            get { return actor; }
            set
            {
                actor = value;
                RaisePropertyChanged(nameof(Actor));
            }
        }

        #endregion

        #region Commands

        public ICommand OpenAddActorPage => new Command(
    async () =>
    {
        var amount = CurrentPage.Navigation.NavigationStack.Where(x => x is AddActorPage).Count();
        if (amount < 1)
        {
            await CoreMethods.PushPageModel<AddActorViewModel>(Actor.Id);
        }
    });
        public ICommand OpenActorMoviesPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<ActorMoviesViewModel>(Actor.Id);
            });
        public ICommand DeleteAlert => new Command(
            async () =>
            {
                await Delete(Actor.Id);
            });

        #endregion
    }
}
