using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class ArtistDataAccess : IArtistDataAccess
    {
        private SongDirectoryContext Context { get; }
        private IMapper Mapper { get; }

        public ArtistDataAccess(SongDirectoryContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<Artist> GetByAsync(IArtistContainer artist)
        {
            return Mapper.Map<Artist>(await Context.Artist.FirstOrDefaultAsync(x => x.Id == artist.ArtistId));
        }
    }
}