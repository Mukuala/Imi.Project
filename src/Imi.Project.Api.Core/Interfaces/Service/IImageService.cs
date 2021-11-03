using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IImageService
    {
        Task<string> AddOrUpdateImageAsync<T>(Movie? movie, Actor? actor, ApplicationUser? user, IFormFile image);
    }
}