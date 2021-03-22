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
    public class SongDataAccess : ISongDataAccess
    {
        private SongDirectoryContext Context { get; }
        private IMapper Mapper { get; }


        public SongDataAccess(SongDirectoryContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<Song> InsertAsync(SongUpdateModel song)
        {
            var result = await Context.AddAsync(Mapper.Map<DataAccess.Entities.Song>(song));
            await Context.SaveChangesAsync();

            return Mapper.Map<Song>(result.Entity);
        }

        public async Task<IEnumerable<Song>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Song>>(
                await Context.Song.Include(x => x.Album).ThenInclude(x => x.Artist).ToListAsync());
        }

        public async Task<Song> GetAsync(ISongIdentity songId)
        {
            var result = await Get(songId);
            return Mapper.Map<Song>(result);
        }

        private async Task<object> Get(ISongIdentity song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }

            return await Context.Song.Include(x => x.Album)
                .FirstOrDefaultAsync(x => x.Id == song.Id);
        }


        public async Task<Song> UpdateAsync(SongUpdateModel song)
        {
            var existing = await Get(song);
            var result = Mapper.Map(song, existing);
            Context.Update(result);
            await Context.SaveChangesAsync();
            return Mapper.Map<Song>(result);
        }
    }
}