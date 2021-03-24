using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Domain.Models;
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
            return Mapper.Map<Artist>(await Context.Artist
                .FirstOrDefaultAsync(x => x.Id == artist.ArtistId));
        }

        public async Task<IEnumerable<Artist>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Artist>>(
                await Context.Artist.ToListAsync());
        }

        public async Task<Artist> InsertAsync(ArtistUpdateModel artist)
        {
            var result = await Context.AddAsync(Mapper.Map<DataAccess.Entities.Artist>(artist));
            await Context.SaveChangesAsync();

            return Mapper.Map<Artist>(result.Entity);
        }

        public async Task<Artist> UpdateAsync(ArtistUpdateModel artist)
        {
            var existing = await Get(artist);
            var result = Mapper.Map(artist, existing);
            Context.Update(result);
            await Context.SaveChangesAsync();
            return Mapper.Map<Artist>(result);
        }

        private async Task<object> Get(ISongIdentity artist)
        {
            if (artist == null)
            {
                throw new ArgumentNullException(nameof(artist));
            }

            return await Context.Artist.Include(x => x.Album)
                .FirstOrDefaultAsync(x => x.Id == artist.Id);
        }
    }
}