using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _webHostEnvironment;
        private readonly IMovieRepository _movieRepo;
        private readonly IActorRepository _actorRepo;
        private readonly IUserRepository _userRepo;

        public ImageService(IHostEnvironment webHostEnvironment, IMovieRepository movieRepo, IActorRepository actorRepo, IUserRepository userRepo)
        {
            _webHostEnvironment = webHostEnvironment;
            _movieRepo = movieRepo;
            _actorRepo = actorRepo;
            _userRepo = userRepo;
        }

        public async Task<string> AddOrUpdateImageAsync<TRequestDto>(IFormFile image, string id, bool isDelete)
        {
            string oldImageName;
            var requestDtoType = typeof(TRequestDto);
            var ImgFolderName = requestDtoType.Name.Replace("RequestDto", "") + "Img";
            int intId;
            //Checks if id is an int or guid, returns false when guid
            var canParseId = int.TryParse(id, out intId);

            if (image == null && !isDelete)
            {
                if (canParseId)
                {
                    return await CheckIntIdReturnImageString(intId, requestDtoType);
                }
                else
                {
                    return await CheckStringIdReturnImageString(id);
                }
            }

            if (canParseId && intId != 0)
            {
                oldImageName = await CheckIntIdReturnImageString(intId, requestDtoType);
                if (oldImageName != null)
                {
                    DeleteOldImage(oldImageName);
                }
            }

            else if (!canParseId && !string.IsNullOrEmpty(id))
            {
                oldImageName = await CheckStringIdReturnImageString(id);
                if (oldImageName != null && !oldImageName.Contains("https://robohash.org/"))
                {
                    DeleteOldImage(oldImageName);
                }
            }

            void DeleteOldImage(string eImageString)
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", eImageString);
                File.Delete(oldImagePath);
            }

            if (isDelete)
            {
                return null;
            }

            var pathForDatabase = Path.Combine("Images", ImgFolderName);

            var folderPathForImages = Path.Combine(
                _webHostEnvironment.ContentRootPath, "wwwroot", pathForDatabase);


            if (!Directory.Exists(folderPathForImages))
            {
                Directory.CreateDirectory(folderPathForImages);
            }

            var AllFolderPathImages = Directory.GetFiles(folderPathForImages);

            var newFileNameWithExtension = $"{image.FileName}";

            var filePath = Path.Combine(folderPathForImages, newFileNameWithExtension);

            bool ImageAlreadyExists = AllFolderPathImages.Any(x => x.Equals(filePath));


            if (image.Length > 0 && ImageAlreadyExists == false)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }

            var filePathForDatabase = Path.Combine(pathForDatabase, newFileNameWithExtension);

            string imagePath = filePathForDatabase.Replace("\\", "/");
            await UpdateEntity(canParseId, id, intId, typeof(TRequestDto), imagePath);
            return imagePath;
        }
        private async Task<string> CheckIntIdReturnImageString(int id, Type dtoType)
        {
            if (id != 0)
            {
                if (dtoType == typeof(MovieRequestDto))
                {
                    var movie = await _movieRepo.GetByIdAsync(id);
                    return movie.Image;
                }
                else if (dtoType == typeof(ActorRequestDto))
                {
                    var actor = await _actorRepo.GetByIdAsync(id);
                    return actor.Image;
                }
            }
            return null;

        }
        private async Task<string> CheckStringIdReturnImageString(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var user = await _userRepo.GetByIdAsync(id);
                return user.Image;
            }
            return null;
        }

        private async Task UpdateEntity(bool canParseId, string id, int intId, Type dtoType, string imageString)
        {
            if (canParseId)
            {
                if (dtoType == typeof(MovieRequestDto))
                {
                    var movie = await _movieRepo.GetByIdAsync(intId);
                    movie.Image = imageString;
                    await _movieRepo.UpdateAsync(movie);
                }
                else if (dtoType == typeof(ActorRequestDto))
                {
                    var actor = await _actorRepo.GetByIdAsync(intId);
                    actor.Image = imageString;
                    await _actorRepo.UpdateAsync(actor);
                }
            }
            else
            {
                var user = await _userRepo.GetByIdAsync(id);
                user.Image = imageString;
                await _userRepo.UpdateAsync(user);
            }
        }
    }
}
