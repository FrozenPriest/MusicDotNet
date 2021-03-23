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
    [Route("api/[controller]")]
    public class AlbumController:ControllerBase
    {
        private ILogger<AlbumController> Logger { get; }
        private IAlbumCreateService AlbumCreateService { get; }
        private IAlbumGetService AlbumGetService { get; }
        private IAlbumUpdateService AlbumUpdateService { get; }
        private IMapper Mapper { get; }

        public AlbumController(ILogger<AlbumController> logger, IMapper mapper, IAlbumCreateService albumCreateService, IAlbumGetService albumGetService, IAlbumUpdateService albumUpdateService)
        {
            this.Logger = logger;
            this.AlbumCreateService = albumCreateService;
            this.AlbumGetService = albumGetService;
            this.AlbumUpdateService = albumUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<AlbumDTO> PutAsync(AlbumCreateDTO album)
        {
            this.Logger.LogTrace("PutAsync called");

            var result = await this.AlbumCreateService.CreateAsync(this.Mapper.Map<AlbumUpdateModel>(album));

            return this.Mapper.Map<AlbumDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<AlbumDTO> PatchAsync(AlbumUpdateDTO album)
        {
            this.Logger.LogTrace("PutAsync called");

            var result = await this.AlbumUpdateService.UpdateAsync(this.Mapper.Map<AlbumUpdateModel>(album));

            return this.Mapper.Map<AlbumDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<AlbumDTO>> GetAsync()
        {
            this.Logger.LogTrace("GetAsync called");

            return this.Mapper.Map<IEnumerable<AlbumDTO>>(await this.AlbumGetService.GetAsync());
        }

        [HttpGet]
        [Route("{albumId}")]
        public async Task<AlbumDTO> GetAsync(int albumId)
        {
            this.Logger.LogTrace($"GetAsync called for {albumId}");

            return this.Mapper.Map<AlbumDTO>(await this.AlbumGetService.GetAsync(new AlbumIdentityModel(albumId)));
        }
    }
}