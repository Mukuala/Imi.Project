using Imi.Project.Wpf.Infrastructure;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            var newForm = new MainWindow(); //creates your new form
            newForm.Show(); //shows the new form
            this.Close(); //closes this form
        }
    }
}
