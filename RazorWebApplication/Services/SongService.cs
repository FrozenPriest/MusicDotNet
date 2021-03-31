using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public class SongService : ISongService
    {
        private HttpClient HttpClient { get; }

        public SongService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<SongModel>> GetAll()
        {
            using var response = await this.HttpClient.GetAsync("api/v1/song");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<IEnumerable<SongModel>>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return result;
        }

        public async Task<SongModel> GetById(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/v1/song/" + id);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<SongModel>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return result;
        }
    }
}