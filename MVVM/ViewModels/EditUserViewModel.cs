using System.ComponentModel;
using System.Runtime.CompilerServices;
using MAIN_POS.APIServices;
using MAIN_POS.MVVM.Models;
using MAIN_POS.MVVM.Views;

namespace MAIN_POS.MVVM.ViewModels
{
    public class EditUserViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices api = new ApiServices();
        private readonly User _user;

        private string name;
        private string username;
        private string email;
        private string password;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public Command SaveCommand { get; }

        public EditUserViewModel(User user)
        {
            _user = user;

            Name = user.Name;
            Username = user.Username;
            Email = user.Email;
            Password = user.Password;

            SaveCommand = new Command(async () => await SaveUser());
        }

        private async Task SaveUser()
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            _user.Name = Name;
            _user.Username = Username;
            _user.Email = Email;
            _user.Password = Password;

            bool result = await api.UpdateUser(_user);

            if (result)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "User updated successfully.", "OK");
                Application.Current.MainPage = new UserManagementView();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to update user.", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}