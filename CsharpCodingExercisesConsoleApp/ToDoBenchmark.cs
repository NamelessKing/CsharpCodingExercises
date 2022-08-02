using BenchmarkDotNet.Attributes;
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
    public class TodoBenchmark
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly RestClient restClient = new RestClient("https://jsonplaceholder.typicode.com/");
        public TodoBenchmark()
        {
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        [Benchmark]
        public async Task<List<Todo>?> GetAllTodos_HttpClient()
        {
            var response = await httpClient.GetAsync("todos");
            var todos = await response.Content.ReadFromJsonAsync<List<Todo>>();
            return todos;
        }
        [Benchmark]
        public async Task<List<Todo>?> GetAllTodos_RestSharp()
        {
            var request = new RestRequest("todos");
            var todos = await restClient.GetAsync<List<Todo>>(request);
            return todos;
        }
    }



    public class Todo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public bool Completed { get; set; }
    }
}
