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
    public class SongController : ControllerBase
    {
        private ILogger<SongController> Logger { get; }
        private ISongCreateService SongCreateService { get; }
        private ISongGetService SongGetService { get; }
        private ISongUpdateService SongUpdateService { get; }
        private ISongDeleteService SongDeleteService { get; }

        private IMapper Mapper { get; }

        public SongController(ILogger<SongController> logger, IMapper mapper, ISongCreateService songCreateService,
            ISongGetService songGetService, ISongUpdateService songUpdateService, ISongDeleteService songDeleteService)
        {
            this.Logger = logger;
            this.SongCreateService = songCreateService;
            this.SongGetService = songGetService;
            this.SongUpdateService = songUpdateService;
            this.SongDeleteService = songDeleteService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<SongDTO> PutAsync(SongCreateDTO song)
        {
            this.Logger.LogTrace("PutAsync called");

            var result = await this.SongCreateService.CreateAsync(this.Mapper.Map<SongUpdateModel>(song));

            return this.Mapper.Map<SongDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<SongDTO> PatchAsync(SongUpdateDTO song)
        {
            this.Logger.LogTrace("PutAsync called");

            var result = await this.SongUpdateService.UpdateAsync(this.Mapper.Map<SongUpdateModel>(song));

            return this.Mapper.Map<SongDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<SongDTO>> GetAsync()
        {
            this.Logger.LogTrace("GetAsync called");

            return this.Mapper.Map<IEnumerable<SongDTO>>(await this.SongGetService.GetAsync());
        }

        [HttpGet]
        [Route("{songId}")]
        public async Task<SongDTO> GetAsync(int songId)
        {
            this.Logger.LogTrace($"GetAsync called for {songId}");

            return this.Mapper.Map<SongDTO>(await this.SongGetService.GetAsync(new SongIdentityModel(songId)));
        }

        [HttpDelete]
        [Route("{songId}")]
        public async Task DeleteAsync(int songId)
        {
            this.Logger.LogTrace($"DeleteAsync called for {songId}");
            
            await this.SongDeleteService.DeleteAsync(new SongIdentityModel(songId));
        }
    }
}