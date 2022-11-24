using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebClient
{
    /// <summary>
    /// �������������� � ��������
    /// </summary>
    public class UserCreateRequest
    {
        private string serverAddress = $"https://localhost:5001/";
        
        /// <summary>
        /// �������� ������� �� id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task GetUser(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(serverAddress + $"users/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"������ � ������� {id} �� ������!");
                return;
            }
            Users user = await response.Content.ReadFromJsonAsync<Users>();
            user.PrintMe();
        }



        /// <summary>
        /// �������� ������� � ��
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUser(Users user)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync(serverAddress + $"users", user);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                Console.WriteLine($"������ � ������� {user.Id} ��� ����������!");
                return;
            }
            Console.WriteLine("������ ������� ��������!");
        }
    }
}