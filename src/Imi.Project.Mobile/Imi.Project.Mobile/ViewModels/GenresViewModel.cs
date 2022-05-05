using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Utils;
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
    public class GenresViewModel : FreshBasePageModel
    {
        private readonly IApiService<GenreResponseDto, GenreRequestDto> _genreApiService;
        public GenresViewModel(IApiService<GenreResponseDto, GenreRequestDto> genreApiService)
        {
            _genreApiService = genreApiService;
        }
        public override async void Init(object initData)
        {
            base.Init(initData);
            await FillGenres();
        }
        private async Task Delete(int id)
        {
            var name = Genres.FirstOrDefault(g => g.Id == id).Name;
            var alert = await CoreMethods.DisplayAlert("Delete", $"Are you sure you want to delete {name} genre?", "Yes", "No");
            if (alert)
            {
                await _genreApiService.DeleteCallApi(id.ToString(), GetJwtToken.JwtToken);
            }
        }

        private async Task Edit(string name)
        {
            try
            {
                var result = await CurrentPage.DisplayPromptAsync("Edit", null, "Ok", "Cancel", null, -1, null, name);
                if (!string.IsNullOrWhiteSpace(result) && result != name)
                {
                    var genre = Genres.FirstOrDefault(x => x.Name == name);
                    GenreRequestDto updatedGenre = new GenreRequestDto
                    {
                        Id = genre.Id,
                        Name = result
                    };
                    await _genreApiService.PutCallApi(genre.Id.ToString(), updatedGenre, GetJwtToken.JwtToken);
                }
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }
        }
        private async Task Add()
        {
            try
            {
                var result = await CurrentPage.DisplayPromptAsync("Add", null, "Ok", "Cancel", null, -1, null, "");
                if (!string.IsNullOrWhiteSpace(result))
                {
                    GenreRequestDto newGenre = new GenreRequestDto
                    {
                        Name = result
                    };
                    await _genreApiService.PostCallApi(newGenre, GetJwtToken.JwtToken);
                }
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }
        }
        private async Task FillGenres()
        {
            IsBusy = true;
            try
            {
                Genres = null;
                var apigenres = await _genreApiService.GetAllAsync();
                Genres = new ObservableCollection<GenreResponseDto>(apigenres);
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

        private ObservableCollection<GenreResponseDto> genres;
        public ObservableCollection<GenreResponseDto> Genres
        {
            get { return genres; }
            set
            {
                genres = value;
                RaisePropertyChanged(nameof(Genres));
            }
        }
        private string genreName;
        public string GenreName
        {
            get { return genreName; }
            set
            {
                genreName = value;
                RaisePropertyChanged(nameof(GenreName));
            }
        }

        #endregion

        #region Commands

        public ICommand AddPrompt => new Command(
            async () =>
            {
                await Add();
                await FillGenres();
            });
        public ICommand EditPrompt => new Command<string>(
            async (string name) =>
            {
                await Edit(name);
                await FillGenres();
            });
        public ICommand DeleteAlert => new Command<int>(
            async (int id) =>
            {
                await Delete(id);
                await FillGenres();
            });
        #endregion


    }
}
