using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class ApiUserService : IUserService
    {
        string baseApiUri = WebApiClient.baseUri;
        public async Task<ApplicationUser> CreateAsync(ApplicationUser model)
        {
            var newUser = await WebApiClient.PostCallApi<ApplicationUser, ApplicationUser>($"{baseApiUri}", model);
            return newUser;
        }

        public async Task<ApplicationUser> DeleteAsync(string id)
        {
            return await WebApiClient.DeleteCallApi<ApplicationUser>($"{baseApiUri}Users/{id}");
        }

        public async Task<ICollection<ApplicationUser>> GetAllAsync()
        {
            return await WebApiClient.GetApiResult<ICollection<ApplicationUser>>($"{baseApiUri}Users");
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await WebApiClient.GetApiResult<ApplicationUser>($"{baseApiUri}Users/{id}");
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser model)
        {
            return await WebApiClient.PutCallApi<ApplicationUser, ApplicationUser>($"{baseApiUri}Users/{model.Id}", model);
        }
    }
}
