using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Contracts;
using Client.DTO.Read;
using Client.Requests.Create;
using Client.Requests.Update;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ArtistController : ControllerBase
    {
        private ILogger<ArtistController> Logger { get; }
        private IArtistCreateService ArtistCreateService { get; }
        private IArtistGetService ArtistGetService { get; }
        private IArtistUpdateService ArtistUpdateService { get; }
        private IMapper Mapper { get; }

        public ArtistController(ILogger<ArtistController> logger, IMapper mapper,
            IArtistCreateService artistCreateService, IArtistGetService artistGetService,
            IArtistUpdateService artistUpdateService)
        {
            this.Logger = logger;
            this.ArtistCreateService = artistCreateService;
            this.ArtistGetService = artistGetService;
            this.ArtistUpdateService = artistUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ArtistDTO> PutAsync(ArtistCreateDTO artist)
        {
            this.Logger.LogTrace("PutAsync called");

            var result = await this.ArtistCreateService.CreateAsync(this.Mapper.Map<ArtistUpdateModel>(artist));

            return this.Mapper.Map<ArtistDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<ArtistDTO> PatchAsync(ArtistUpdateDTO artist)
        {
            this.Logger.LogTrace("PutAsync called");

            var result = await this.ArtistUpdateService.UpdateAsync(this.Mapper.Map<ArtistUpdateModel>(artist));

            return this.Mapper.Map<ArtistDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ArtistDTO>> GetAsync()
        {
            this.Logger.LogTrace("GetAsync called");

            return this.Mapper.Map<IEnumerable<ArtistDTO>>(await this.ArtistGetService.GetAsync());
        }

        [HttpGet]
        [Route("{artistId}")]
        public async Task<ArtistDTO> GetAsync(int artistId)
        {
            this.Logger.LogTrace($"GetAsync called for {artistId}");

            return this.Mapper.Map<ArtistDTO>(await this.ArtistGetService.GetAsync(new ArtistIdentityModel(artistId)));
        }
    }
}