using MAIN_POS.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MAIN_POS.APIServices
{
    public class ApiServices
    {
        HttpClient client;

        public ApiServices()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://69ba5052b3dcf7e0b4bc859c.mockapi.io/");
        }

        public async Task<User> Login(string Username, string Password)
        {
            var response = await client.GetAsync("User");
            if (!response.IsSuccessStatusCode) return null;

            var users = await response.Content.ReadFromJsonAsync<List<User>>();
            return users?.FirstOrDefault(u => u.Username == Username && u.Password == Password);
        }

        public async Task<bool> Register(User newUser)
        {
            var response = await client.PostAsJsonAsync("User", newUser);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<User>> GetUsers()
        {
            var response = await client.GetAsync("User");

            if (!response.IsSuccessStatusCode)
                return new List<User>();

            var users = await response.Content.ReadFromJsonAsync<List<User>>();
            return users ?? new List<User>();
        }

        public async Task<bool> UpdateUser(User updatedUser)
        {
            if (updatedUser == null || string.IsNullOrEmpty(updatedUser.UserID))
                return false;

            var response = await client.PutAsJsonAsync($"User/{updatedUser.UserID}", updatedUser);
            return response.IsSuccessStatusCode;
        }
    }
}
