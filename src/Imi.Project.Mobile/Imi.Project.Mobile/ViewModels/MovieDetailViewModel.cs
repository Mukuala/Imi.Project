using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Pages;
using Imi.Project.Mobile.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MovieDetailViewModel : FreshBasePageModel
    {
        private readonly IApiService<MovieResponseDto, MovieRequestDto> _apiService;
        public MovieDetailViewModel(IApiService<MovieResponseDto, MovieRequestDto> apiService)
        {
            _apiService = apiService;
        }

        public override void Init(object initData)
        {
            Movie = initData as MovieResponseDto;
            GenresListText = String.Join(", ", Movie.Genres.Select(g => g.Name));
            ActorsListText = String.Join(", ", Movie.Actors.Select(a => a.Name));
        }

        private async Task Delete(int id)
        {
            var alert = await CoreMethods.DisplayAlert("Delete", $"Are you sure you want to delete {Movie.Name}?", "Yes", "No");
            if (alert)
            {
                await _apiService.DeleteCallApi(id.ToString(), GetJwtToken.JwtToken);
                await CoreMethods.PopPageModel();
            }

        }
        #region Properties

        private MovieResponseDto movie;
        public MovieResponseDto Movie
        {
            get { return movie; }
            set
            {
                movie = value;
                RaisePropertyChanged(nameof(Movie));
            }
        }
        private string genresListText;
        public string GenresListText
        {
            get { return genresListText; }
            set
            {
                genresListText = value;
                RaisePropertyChanged(nameof(GenresListText));
            }
        }
        private string actorsListText;
        public string ActorsListText
        {
            get { return actorsListText; }
            set
            {
                actorsListText = value;
                RaisePropertyChanged(nameof(ActorsListText));
            }
        }
        #endregion
        #region Commands
        public ICommand OpenAddMoviePage => new Command(
            async () =>
            {
                var amount = CurrentPage.Navigation.NavigationStack.Where(x => x is AddMoviePage).Count();
                if (amount < 1)
                {
                    await CoreMethods.PushPageModel<AddMovieViewModel>(Movie);
                }
            });
        public ICommand DeleteAlert => new Command(
            async () =>
            {
                await Delete(Movie.Id);
            });

        #endregion
    }
}
