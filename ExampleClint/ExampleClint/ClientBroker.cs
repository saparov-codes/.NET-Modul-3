using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExampleClint;

public class ClientBroker
{
    private readonly HttpClient _httpClient;
    private readonly string _host;

    public ClientBroker()
    {
        _host = "https://localhost:7050/api/Movie"; // To‘g‘ri API bazaviy URL
        _httpClient = new HttpClient();
    }

    public async Task GetAllAsync()
    {
        var url = $"{_host}/getAllMovie"; // To‘g‘ri endpoint

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Xatolik bo‘lsa, Exception chiqaradi

            string contentString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // JSON maydonlari katta-kichik harflarni e'tiborga olmasin
            };

            var movies = JsonSerializer.Deserialize<Movie[]>(contentString, options);
            if (movies != null && movies.Length > 0)
            {
                foreach (var movie in movies)
                {
                    Console.WriteLine(movie);
                }
            }
            else
            {
                Console.WriteLine("No movies found.");
            }
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine($"HTTP Error: {httpEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xatolik yuz berdi: {ex.Message}");
        }
    }
}