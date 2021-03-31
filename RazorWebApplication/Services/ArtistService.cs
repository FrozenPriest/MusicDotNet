using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public class ArtistService : IArtistService
    {
        private HttpClient HttpClient { get; }

        public ArtistService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<ArtistModel>> GetAll()
        {
            using var response = await this.HttpClient.GetAsync("api/v1/artist");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<IEnumerable<ArtistModel>>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return result;
        }

        public async Task<ArtistModel> GetById(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/v1/artist/" + id);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ArtistModel>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return result;
        }
    }
}