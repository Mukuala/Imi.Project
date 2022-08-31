using Imi.Project.Blazor.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Imi.Project.Blazor.Services.Puzzle
{
    public static class PuzzleService
    {
        private static List<ImagePiece> ImagePieceList = new List<ImagePiece>();
        private static List<string> stringNumbersList = new List<string>();
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
            //Directory with all maps of puzzle images
            string puzzleImagePath = Path.GetFullPath("../Imi.Project.Blazor/wwwroot/PuzzleImages");
            var directories = Directory.GetDirectories(puzzleImagePath).Select(d => new DirectoryInfo(d).Name).ToList();

            return directories;
        }
        public static List<string> GetStringNumbersList()
        {
            stringNumbersList.Clear();
            for (int i = 1; i <= 16; i++)
            {
                stringNumbersList.Add(i.ToString());
            }
            return stringNumbersList;
        }

    }
}
