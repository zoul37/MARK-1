using StudentPortal.Models;
using System.Text.Json;
using System.Net.Http;
namespace StudentDirectory.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7120/api/student");

            if (response.IsSuccessStatusCode)  // ✅ Process successful response
            {
                var data = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Response: {data}");  // Debugging log

                if (String.IsNullOrWhiteSpace(data))
                {
                    Console.WriteLine("API returned an empty response.");
                    return new List<Student>();
                }

                var students = JsonSerializer.Deserialize<List<Student>>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return students ?? new List<Student>();
            }

            Console.WriteLine($"API call failed: {response.StatusCode}");
            return new List<Student>();
        }


    }
}
