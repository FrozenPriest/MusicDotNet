using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Controllers
{
    public class SongController: Controller
    {
        private ISongService SongService { get; }
        private ILogger<SongController> Logger { get; }

        public SongController(ISongService songService, ILogger<SongController> logger)
        {
            SongService = songService;
            Logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            return this.View(await this.SongService.GetAll());
        }

        public async Task<IActionResult> Details(int modelId)
        {
            return this.View(await this.SongService.GetById(modelId));
        }
        
        public async Task<IActionResult> Delete(int modelId)
        {
            await this.SongService.DeleteById(modelId);
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> EditPage(int id)
        {
            return this.View(await this.SongService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditPage(int id, int albumId, string name, int duration)
        {
            await this.SongService.EditSong(new SongUpdateModel{Id=id, Name = name, AlbumId = albumId, Duration = duration});
            return this.View(await this.SongService.GetById(id));
        }
    }
}