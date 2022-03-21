using Imi.Project.Blazor.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Puzzle
{
    public static class PuzzleService
    {
        private static List<ImagePiece> ImagePieceList = new List<ImagePiece>();
        public static int PuzzleImagesAmount = GetImageNames().Count();
        public static List<ImagePiece> GetImagePieces(string imageName)
        {
            ImagePieceList.Clear();
            for (int i = 1; i <= 16; i++)
            {
                ImagePiece imagePiece = new ImagePiece();
                imagePiece.Name = $"{imageName}{i}";
                imagePiece.Id = i;
                imagePiece.Url = $"/PuzzleImages/{imageName}/{imagePiece.Name}.jpg";
                ImagePieceList.Add(imagePiece);
            }
            return ImagePieceList;
        }
        public static List<string> GetImageNames()
        {
            var directories = Directory.GetDirectories("/IMI2.0/Repo/src/Imi.Project.Blazor/wwwroot/PuzzleImages").Select(d=> new DirectoryInfo(d).Name).ToList();

            return directories;
        }

    }
}
