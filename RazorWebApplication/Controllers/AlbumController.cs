using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Controllers
{
    public class AlbumController: Controller
    {
        private IAlbumService AlbumService { get; }

        public AlbumController(IAlbumService albumService)
        {
            AlbumService = albumService;
        }
        
        public async Task<IActionResult> Index()
        {
            return this.View(await this.AlbumService.GetAll());
        }

        public async Task<IActionResult> Details(int modelId)
        {
            return this.View(await this.AlbumService.GetById(modelId));
        }
    }
}