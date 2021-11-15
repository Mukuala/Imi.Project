using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class ApiWatchlistService : ServiceCrudBase<Watchlist>, IWatchlistService
    {
        public async Task<ICollection<Watchlist>> GetWatchlistsByUserId(string userId)
        {
            return await WebApiClient.GetApiResult<ICollection<Watchlist>>($"{baseApiUri}Users/{userId}/{nameof(Watchlist).ToLower()}s");
        }
    }
}
