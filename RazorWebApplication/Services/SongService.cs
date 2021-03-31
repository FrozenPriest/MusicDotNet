using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public async Task DeleteById(int id)
        {
            await this.HttpClient.DeleteAsync("api/v1/song/" + id);
        }

        public async Task EditSong(SongUpdateModel songModel)
        {
            var json = JsonSerializer.Serialize<SongUpdateModel>(songModel);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json-patch+json");
            await HttpClient.PatchAsync("api/v1/song/", content);
        }

        public async Task AddSong(SongCreateModel songModel)
        {
            var json = JsonSerializer.Serialize<SongCreateModel>(songModel);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json-patch+json");
            await HttpClient.PutAsync("api/v1/song/", content);
        }
    }
}