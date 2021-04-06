using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using DataAccess.Context;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Domain.Models;
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
            var result = Mapper.Map<Album>(await Context.Album
                .Select(x => new Album
                {
                    Id = x.Id, Name = x.Name, ImageUrl = x.ImageUrl,
                    Artist = new Artist
                        {Id = x.Artist.Id, Name = x.Artist.Name, ImageUrl = x.Artist.ImageUrl},
                    Song = x.Song.Select(song => new Song {Id = song.Id, Name = song.Name, Duration = song.Duration})
                })
                .FirstOrDefaultAsync(x => x.Id == album.AlbumId));
            result.Artist.Album = null;
            return result;
        }

        public async Task<IEnumerable<Album>> GetAsync()
        {
            var result = Mapper.Map<IEnumerable<Album>>(await Context.Album
                .Select(x => new Album
                {
                    Id = x.Id, Name = x.Name, ImageUrl = x.ImageUrl,
                    Artist = new Artist
                        {Id = x.Artist.Id, Name = x.Artist.Name, ImageUrl = x.Artist.ImageUrl},
                    Song = x.Song.Select(song => new Song {Id = song.Id, Name = song.Name, Duration = song.Duration})
                })
                .ToListAsync());
            var enumerable = result.ToList();
            //enumerable.ForAll(x => x.Artist.Album = null);
            return enumerable;
        }

        public async Task<Album> InsertAsync(AlbumUpdateModel album)
        {
            var result = await Context.AddAsync(Mapper.Map<DataAccess.Entities.Album>(album));
            await Context.SaveChangesAsync();

            return Mapper.Map<Album>(result.Entity);
        }

        public async Task<Album> UpdateAsync(AlbumUpdateModel album)
        {
            var existing = await Get(album);
            var result = Mapper.Map(album, existing);
            Context.Update(result);
            await Context.SaveChangesAsync();
            return Mapper.Map<Album>(result);
        }


        private async Task<object> Get(IAlbumIdentity album)
        {
            if (album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            return await Context.Album
                .Include(x => x.Artist)
                .FirstOrDefaultAsync(x => x.Id == album.Id);
        }
    }
}