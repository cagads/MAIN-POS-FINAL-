using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MAIN_POS.APIServices;
using MAIN_POS.MVVM.Views;


namespace MAIN_POS.MVVM.ViewModels
{
    public class LoginViewModel
    {
        ApiServices api = new ApiServices();

        public string Username { get; set; }
        public string Password { get; set; }
        public Command LoginCommand { get; set; }
        public Command GoToRegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            
            GoToRegisterCommand = new Command(GoToRegister);
        }

        private async void Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Enter username and password", "OK");
                return;
            }

            var user = await api.Login(Username, Password);
            if (user != null)
            {
                Session.CurrentUserRole = user.Role;

                await Application.Current.MainPage.DisplayAlert("Success", "Login Successful", "OK");

                Application.Current.MainPage = new AdminDashboardView();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid Credentials", "OK");
            }
        }
        private async void GoToRegister()
        {
            Application.Current.MainPage = new RegistrationView();
        }

    }
}
