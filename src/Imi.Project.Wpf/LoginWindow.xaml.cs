using Imi.Project.Wpf.Infrastructure;
using System.Windows;
using System.Windows.Controls;

namespace Imi.Project.Wpf
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        WebApiClient webApiClient = new WebApiClient();

        public LoginWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.CanMinimize;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "sfriskey13";
            PasswordBox.Password = "WKlYnFhm0ikG";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)

        {
            btnLogin.IsEnabled = false;
            sfBusy.IsBusy = true;
            LogIn();
        }
        private async void LogIn()
        {
            var result = await webApiClient.Authenticate(txtUsername.Text, PasswordBox.Password);
            //saves jwtToken in properties settings
            Properties.Settings.Default.Token = result.JwtToken;
            Properties.Settings.Default.Save();

            webApiClient.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.JwtToken);
            var mainWindow = new MainWindow(); //creates your new form
            mainWindow.Show(); //shows the new form
            Close(); //closes this form
        }
    }
}
