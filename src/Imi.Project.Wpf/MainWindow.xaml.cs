using Imi.Project.Common.Dtos;
using Imi.Project.Wpf.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Imi.Project.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebApiClient webApiClient = new WebApiClient();
        string token = Properties.Settings.Default.Token;
        byte[] bytes;

        public MainWindow()
        {
            webApiClient.Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            InitializeComponent();
            btnAddMovie.Visibility = Visibility.Hidden;
            btnEditMovie.Visibility = Visibility.Hidden;
            movieDetailsGrid.IsEnabled = false;
            addOrEditGrid.IsEnabled = false;
            PopulateMoviesListBox();
            FillComboBoxesDropDown();
        }

        private void lstMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            movieDetailsGrid.IsEnabled = true;
            PopulateMovieDetail();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClearEditOrAddGrid();
            addOrEditGrid.IsEnabled = true;
            btnAddMovie.Visibility = Visibility.Visible;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            lstMovies.IsEnabled = false;
            PopulateEditMovieGrid();
            btnEditMovie.Visibility = Visibility.Visible;

        }

        private async void btnDeleteMovie_Click(object sender, RoutedEventArgs e)
        {
            var movie = (MovieResponseDto)lstMovies.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Are you sure?", $"Delete {movie.Name}", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                await webApiClient.DeleteMovieAsync((long)movie.Id);
                CLearMovieDetailsGrid();
            }
        }

        private void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            AddMovie();
            PopulateMoviesListBox();
        }

        private void btnEditMovie_Click(object sender, RoutedEventArgs e)
        {
            lstMovies.IsEnabled = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearEditOrAddGrid();
            lstMovies.IsEnabled = true;
        }
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                txbAddedImgPath.Text = openFileDialog.FileName;
                bytes = File.ReadAllBytes(openFileDialog.FileName);
                imgFileImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
        private async void PopulateMoviesListBox()
        {
            var movies = await webApiClient.GetAllAsync();
            lstMovies.ItemsSource = movies;
        }
        private async void PopulateMovieDetail()
        {
            string actors = "";
            string genres = "";
            var m = (MovieResponseDto)lstMovies.SelectedItem;

            sfBusy.IsBusy = true;

            var movie = await webApiClient.GetByIdAsync((long)m.Id);

            foreach (ActorResponseDto actor in movie.Actors)
            {
                actors += actor.Name + Environment.NewLine;
            }
            foreach (GenreResponseDto genre in movie.Genres)
            {
                genres += genre.Name + Environment.NewLine;
            }

            lblId.Content = movie.Id;
            lblName.Content = movie.Name;
            txbDescription.Text = movie.Description;
            lblRating.Content = movie.AverageRating + "/10";
            lblGenres.Content = genres;
            lblActors.Content = actors;
            lblDuration.Content = movie.Duration + " min";
            lblReleaseDate.Content = movie.ReleaseDate.Date;
            EmbedYoutubeTrailer(movie.EmbeddedTrailerUrl);

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(movie.Image, UriKind.Absolute);
            bitmap.EndInit();
            imgImage.Source = bitmap;

            sfBusy.IsBusy = false;
        }
        private void PopulateEditMovieGrid()
        {
            foreach (var item in cmbActors.Items)
            {
                var actor = (ActorResponseDto)item;
                if (true)
                {

                }
            }
            addOrEditGrid.IsEnabled = true;

            var movie = (MovieResponseDto)lstMovies.SelectedItem;
            txtName.Text = movie.Name;
            txtDescription.Text = movie.Description;
            txtRating.Text = movie.AverageRating.ToString();
            txtDuration.Text = movie.Duration.ToString();
            cmbActors.SelectedItems = movie.Actors;
            cmbGenres.SelectedItems = movie.Genres;
            imgFileImage.Source = new BitmapImage(new Uri(movie.Image, UriKind.Absolute));
        }
        private void ClearEditOrAddGrid()
        {
            addOrEditGrid.IsEnabled = false;
            txbAddedImgPath.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
            txtRating.Text = "";
            txtDuration.Text = "";
            cmbActors.SelectedItems = null;
            cmbGenres.SelectedItems = null;
            imgFileImage.Source = null;
            txtEmbedUrl.Text = "";
            btnAddMovie.Visibility = Visibility.Hidden;
            btnEditMovie.Visibility = Visibility.Hidden;
        }
        private void CLearMovieDetailsGrid()
        {
            lblName.Content = "";
            txbDescription.Text = "";
            lblRating.Content = "";
            lblDuration.Content = "";
            lblReleaseDate.Content = "";
            lblActors.Content = "";
            lblGenres.Content = "";
            imgImage.Source = null;
            webEmbbedTrailer.Source = null;
        }
        private void EmbedYoutubeTrailer(string embedUrl)
        {
            string page =
                              "<html>"
                            + "<head><meta http-equiv='X-UA-Compatible' content='IE=11' /></head>"
                            + "<body>" + "\r\n"
                            + "<iframe src=\"" + embedUrl + "\" width=\"300\" height=\"300\" frameborder=\"0\" allowfullscreen></iframe>"
                            + "</body></html>";

            webEmbbedTrailer.NavigateToString(page);
        }
        private async void AddMovie()
        {
            var actors = cmbActors.SelectedItems;
            var genres = cmbGenres.SelectedItems;
            List<long> actorsId = new List<long>();
            List<long> genresId = new List<long>();

            foreach (var item in actors)
            {
                var actor = (ActorResponseDto)item;
                actorsId.Add((long)actor.Id);
            }
            foreach (var item in genres)
            {
                var genre = (GenreResponseDto)item;
                genresId.Add((long)genre.Id);
            }


            MovieRequestDto movie = new MovieRequestDto
            {
                AverageRating = Convert.ToDouble(txtRating.Text),
                Description = txtDescription.Text,
                Duration = Convert.ToInt32(txtDuration.Text),
                EmbeddedTrailerUrl = txtEmbedUrl.Text,
                Name = txtName.Text,
                ReleaseDate = (DateTime)dateReleaseDate.DateTime,
                ActorsId = actorsId,
                GenresId = genresId,
                Image = GetIFromFileFromImgFile(),
            };
            await webApiClient.PostCallApi(movie, token);
        }

        private async void FillComboBoxesDropDown()
        {
            var AllActors = await webApiClient.GetAllActorsAsync();
            var AllGenres = await webApiClient.GetAllGenresAsync();
            cmbActors.ItemsSource = AllActors;
            cmbGenres.ItemsSource = AllGenres;
        }
        public IFormFile GetIFromFileFromImgFile()
        {
            string contentType;
            string imgFilePath = txbAddedImgPath.Text;
            new FileExtensionContentTypeProvider().TryGetContentType(Path.GetFileName(imgFilePath), out contentType);
            using (var stream = File.OpenRead(imgFilePath))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = contentType
                };
                return file;
            }

            //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create((BitmapImage)imgFileImage.Source));
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    encoder.Save(ms);
            //    byte[] bytez = ms.ToArray();
            //    IFormFile file = new FormFile(ms, 0, bytez.Length, null, Path.GetFileName(img));
            //    return file;
            //}
        }
    }
}
