using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCodingExercisesConsoleApp
{
    [MemoryDiagnoser]

    public class ReqResBenchmark
    {

        private readonly string BaseAddress = "https://reqres.in/";
        private static HttpClient HttpClient { get; set; }
        private static RestClient RestClient { get; set; }

        public ReqResBenchmark()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(BaseAddress);
            RestClient = new RestClient(BaseAddress);
        }

        [Benchmark]
        public async Task<UserListPage> GetUserListPageByPageNum_HttpClient()
        {
            try
            {
                var response = await HttpClient.GetAsync($"api/users?page={2}");
                var userListPage = await response.Content.ReadFromJsonAsync<UserListPage>();
                return userListPage;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [Benchmark]
        public async Task<UserListPage> GetUserListPageByPageNum_RestSharp()
        {
            try
            {
                var request = new RestRequest($"/api/users?page={2}");
                var userListPage = await RestClient.GetAsync<UserListPage>(request);
                return userListPage;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Benchmark]
        public async Task<UserToCreateDto> CreateTodo_HttpClient()
        {
            var userToCreateDto = GetUserForCreation();
            var response = await HttpClient.PostAsJsonAsync("/api/users", userToCreateDto);
            var createdUser = await response.Content.ReadFromJsonAsync<UserToCreateDto>();
            return createdUser;
        }
        [Benchmark]
        public async Task<UserToCreateDto> CreateTodo_RestSharp()
        {
            var userToCreateDto = GetUserForCreation();
            var request = new RestRequest("todos").AddJsonBody(userToCreateDto);
            var createdUser = await RestClient.PostAsync<UserToCreateDto>(request);
            return createdUser;
        }



        private static UserToCreateDto GetUserForCreation()
        {
            return new UserToCreateDto()
            {
                Name = "gigio",
                Job = "dev"
            };
        }

    }


    public class UserListPage
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public User[] data { get; set; }
    }



    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }


    public class UserToCreateDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
    }

}
