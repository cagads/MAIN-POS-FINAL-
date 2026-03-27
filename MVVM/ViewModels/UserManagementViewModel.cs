using MAIN_POS.APIServices;
using MAIN_POS.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAIN_POS.MVVM.ViewModels
{
    public class UserManagementViewModel
    {
        private readonly ApiServices api = new ApiServices();

        public ObservableCollection<User> Users { get; set; } = new();

        public string SearchText { get; set; }

        public Command LoadUsersCommand { get; }

        public UserManagementViewModel()
        {
            LoadUsersCommand = new Command(async () => await LoadUsers());
        }

        private async Task LoadUsers()
        {
            var users = await api.GetUsers();

            await Application.Current.MainPage.DisplayAlert("DEBUG", $"Users found: {users.Count}", "OK");

            Users.Clear();

            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}
