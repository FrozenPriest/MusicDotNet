using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Controllers
{
    public class ArtistController: Controller
    {
        private IArtistService ArtistService { get; }

        public ArtistController(IArtistService artistService)
        {
            ArtistService = artistService;
        }
        
        public async Task<IActionResult> Index()
        {
            return this.View(await this.ArtistService.GetAll());
        }

        public async Task<IActionResult> Details(int modelId)
        {
            return this.View(await this.ArtistService.GetById(modelId));
        }
    }
}