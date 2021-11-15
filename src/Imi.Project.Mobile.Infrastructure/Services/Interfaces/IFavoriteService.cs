using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Interfaces
{
    public interface IFavoriteService: IServiceCrudBase<Favorite>
    {
        Task<ICollection<Favorite>> GetFavoritesByUserId(string userId);
    }
}
