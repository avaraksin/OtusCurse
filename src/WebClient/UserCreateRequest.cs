using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebClient
{
    public class UserCreateRequest
    {
        private string serverAddress = $"https://localhost:5001/";
        public async Task GetUser(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(serverAddress + $"users/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Клиент с номером {id} не найден!");
                return;
            }
            Users user = await response.Content.ReadFromJsonAsync<Users>();
            user.PrintMe();
        }

        public async Task AddUser(Users user)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync(serverAddress + $"users", user);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                Console.WriteLine($"Клиент с номером {user.Id} уже существует!");
                return;
            }
            Console.WriteLine("Клиент успешно добавлен!");
        }
    }
}