using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public class AlbumService : IAlbumService
    {
        private HttpClient HttpClient { get; }

        public AlbumService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<AlbumModel>> GetAll()
        {
            using var response = await this.HttpClient.GetAsync("api/v1/album");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<IEnumerable<AlbumModel>>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return result;
        }

        public async Task<AlbumModel> GetById(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/v1/album/" + id);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<AlbumModel>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return result;
        }
    }
}