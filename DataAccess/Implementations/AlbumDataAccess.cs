using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class AlbumDataAccess : IAlbumDataAccess
    {
        private SongDirectoryContext Context { get; }
        private IMapper Mapper { get; }


        public AlbumDataAccess(SongDirectoryContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<Album> GetByAsync(IAlbumContainer album)
        {
            return album.AlbumId.HasValue
                ? Mapper.Map<Album>(await Context.Album.FirstOrDefaultAsync(x => x.Id == album.AlbumId))
                : null;
        }
    }
}