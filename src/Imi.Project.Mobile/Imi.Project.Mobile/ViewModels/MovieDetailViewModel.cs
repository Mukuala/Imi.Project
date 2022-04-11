using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class MovieDetailViewModel : FreshBasePageModel
    {

        public override void Init(object initData)
        {
            Movie = initData as MovieResponseDto;
            GenresListText = String.Join(", ", Movie.Genres.Select(g => g.Name));
            ActorsListText = String.Join(", ", Movie.Actors.Select(a => a.Name));
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

        #endregion
    }
}
