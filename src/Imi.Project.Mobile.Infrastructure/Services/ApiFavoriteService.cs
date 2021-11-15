using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class ApiFavoriteService : ServiceCrudBase<Favorite>, IFavoriteService
    {
        public async Task<ICollection<Favorite>> GetFavoritesByUserId(string userId)
        {
            return await WebApiClient.GetApiResult<ICollection<Favorite>>($"{baseApiUri}Users/{userId}/{nameof(Favorite).ToLower()}s");
        }
    }
}
