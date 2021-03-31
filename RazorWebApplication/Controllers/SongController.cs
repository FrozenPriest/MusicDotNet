using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Controllers
{
    public class SongController: Controller
    {
        private ISongService SongService { get; }

        public SongController(ISongService songService)
        {
            SongService = songService;
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
    }
}