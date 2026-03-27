using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAIN_POS.APIServices;
using MAIN_POS.MVVM.Models;

namespace MAIN_POS.MVVM.ViewModels
{
    public class RegistrationViewModel
    {

        ApiServices api = new ApiServices();

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public Command RegisterCommand { get; set; }
        public Command GoToLoginCommand { get; set; }

        public RegistrationViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
            
        }

        private async Task Register()
        {
            // ✅ Validation
            if (string.IsNullOrEmpty(Role)||
                string.IsNullOrEmpty(Name)||
                string.IsNullOrEmpty(Email)||
                string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }

            if (Role == "Admin" && Session.CurrentUserRole != "Admin")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Only an Admin can create another Admin", "OK");
                return;
            }

            var newUser = new User
            {
                Role = Role,
                Name = Name,
                Email = Email,
                Username = Username,
                Password = Password
            };

            var success = await api.Register(newUser);

            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Account Created", "OK");

                // Navigate back to Login
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Registration Failed", "OK");
            }
        }

        

    }
}
