using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class ServiceCrudBase<T> : IServiceCrudBase<T> where T : BaseModel
    {
        public string baseApiUri = WebApiClient.baseUri;
        public async Task<T> GetByIdAsync(long id)
        {
            return await WebApiClient.GetApiResult<T>($"{baseApiUri}{nameof(T).ToLower()}s/{id}");
        }

        public async Task<T> CreateAsync(T model)
        {
            return await WebApiClient.PostCallApi<T, T>($"{baseApiUri}", model);
        }

        public async Task<T> DeleteAsync(long id)
        {
            return await WebApiClient.DeleteCallApi<T>($"{baseApiUri}{nameof(T).ToLower()}s/{id}");
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await WebApiClient.GetApiResult<ICollection<T>>($"{baseApiUri}{nameof(T).ToLower()}s");
        }

        public async Task<T> UpdateAsync(T model)
        {
            return await WebApiClient.PutCallApi<T, T>($"{baseApiUri}{nameof(T).ToLower()}s/{model.Id}", model);
        }
    }
}
