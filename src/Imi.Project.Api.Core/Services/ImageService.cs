using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _webHostEnvironment;

        public ImageService(IHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        string entityImageString;

        public async Task<string> AddOrUpdateImageAsync<T>(Movie? movie, Actor? actor,ApplicationUser? user, IFormFile image)
        {
            if (movie != null && !string.IsNullOrEmpty(movie.Image))
            {
                entityImageString = movie.Image;
                DeleteOldImage(entityImageString);

            }
            if (actor != null && !string.IsNullOrEmpty(actor.Image))
            {
                entityImageString = actor.Image;
                DeleteOldImage(entityImageString);
            }
            if (user != null && !string.IsNullOrEmpty(user.Image))
            {
                entityImageString = user.Image;
                DeleteOldImage(entityImageString);
            }

            void DeleteOldImage(string eImageString)
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", eImageString);
                File.Delete(oldImagePath);
            }

            var pathForDatabase = Path.Combine("Images", typeof(T).Name+"Img"); 

            var folderPathForImages = Path.Combine(
                _webHostEnvironment.ContentRootPath,"wwwroot",pathForDatabase);


            if (!Directory.Exists(folderPathForImages))
            {
                Directory.CreateDirectory(folderPathForImages);
            }

            var fileExtension = Path.GetExtension(image.FileName);

            var newFileNameWithExtension = $"{image.Name}{fileExtension}";

            var filePath = Path.Combine(folderPathForImages, newFileNameWithExtension);

            if (image.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }

            var filePathForDatabase = Path.Combine(pathForDatabase, newFileNameWithExtension);

            return filePathForDatabase.Replace("\\", "/");
        }
        //public void DeleteImage<T>(T dto)
        //{

        //}
    }
}
