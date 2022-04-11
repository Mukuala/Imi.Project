using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
   public class ActorsViewModel: FreshBasePageModel
    {
        private readonly IApiService<ActorResponseDto, ActorRequestDto> _actorApiService;
        public ActorsViewModel(IApiService<ActorResponseDto, ActorRequestDto> actorApiService)
        {
            _actorApiService = actorApiService;
        }

        public override async void Init(object initData)
        {
            base.Init(initData);
            await FillActors();
        }

        private async Task Search()
        {
            var apiActors = await _actorApiService.GetAllAsync();
            var foundActors = apiActors.Where(m => m.Name.ToUpper().Contains(SearchText.ToUpper()));
            Actors = new ObservableCollection<ActorResponseDto>(foundActors);
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
        #endregion
        #region Command
        public ICommand SearchItem => new Command(
    async () =>
    {
        await Search();
    });
        #endregion


    }
}
