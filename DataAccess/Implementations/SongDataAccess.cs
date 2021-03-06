using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = await Context.Song
                .Select(x => new Song
                {
                    Id = x.Id, Name = x.Name, Duration = x.Duration,
                    Album = new Album
                    {
                        Id = x.Album.Id, Name = x.Album.Name, ImageUrl = x.Album.ImageUrl,
                        Artist = new Artist
                            {Id = x.Album.Artist.Id, Name = x.Album.Artist.Name, ImageUrl = x.Album.Artist.ImageUrl}
                    }
                })
                .ToListAsync();
            return Mapper.Map<IEnumerable<Song>>(result);
        }

        public async Task<Song> GetAsync(ISongIdentity id)
        {
            var result = await Get(id);
            return Mapper.Map<Song>(result);
        }

        private async Task<object> Get(ISongIdentity song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }

            return await Context.Song
                .Select(x => new Song
                {
                    Id = x.Id, Name = x.Name, Duration = x.Duration,
                    Album = new Album
                    {
                        Id = x.Album.Id, Name = x.Album.Name, ImageUrl = x.Album.ImageUrl,
                        Artist = new Artist
                            {Id = x.Album.Artist.Id, Name = x.Album.Artist.Name, ImageUrl = x.Album.Artist.ImageUrl}
                    }
                })
                .FirstOrDefaultAsync(x => x.Id == song.Id);
            // return await Context.Song.IgnoreAutoIncludes()
            //     .Include(x => x.Album)
            //     .ThenInclude(x => x.Artist)
            //     .FirstOrDefaultAsync(x => x.Id == song.Id);
        }


        public async Task<Song> UpdateAsync(SongUpdateModel song)
        {
            var existing = await Get(song);
            var result = Mapper.Map(song, existing);
            Context.Update(result);
            await Context.SaveChangesAsync();
            return Mapper.Map<Song>(result);
        }

        public async Task DeleteAsync(ISongIdentity id)
        {
            var song = await Context.Song
                .Include(x => x.Album)
                .FirstOrDefaultAsync(x => x.Id == id.Id);
            Context.Song.Remove(song);
            await Context.SaveChangesAsync();
        }
    }
}