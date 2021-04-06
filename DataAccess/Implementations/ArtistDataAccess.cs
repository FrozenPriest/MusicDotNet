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
            var result = Mapper.Map<Artist>(await Context.Artist.IgnoreAutoIncludes()
                .Include(x => x.Album)
                .ThenInclude(x => x.Song)
                .FirstOrDefaultAsync(x => x.Id == artist.ArtistId));
            result.Album.ForAll(x => x.Artist = null);
            return result;
        }

        public async Task<IEnumerable<Artist>> GetAsync()
        {
           return 
                Mapper.Map<IEnumerable<Artist>>(await Context.Artist
                .Select(x =>
                    new Artist
                    {
                        Id = x.Id, Name = x.Name, ImageUrl = x.ImageUrl,
                        Album = x.Album.Select(album =>
                            new Album
                            {
                                Id = album.Id, 
                                Name = album.Name, 
                                ImageUrl = album.ImageUrl,
                                Song = album.Song.Select(song =>
                                    new Song
                                        {Id = song.Id, Name = song.Name, Duration = song.Duration}
                                )
                            })
                    })
                    .ToListAsync());
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

        private async Task<object> Get(IArtistIdentity artist)
        {
            if (artist == null)
            {
                throw new ArgumentNullException(nameof(artist));
            }

            return await Context.Artist
                .Select(x =>
                    new Artist
                    {
                        Id = x.Id, Name = x.Name, ImageUrl = x.ImageUrl,
                        Album = x.Album.Select(album =>
                            new Album
                            {
                                Id = album.Id, 
                                Name = album.Name, 
                                ImageUrl = album.ImageUrl,
                                Song = album.Song.Select(song =>
                                    new Song
                                        {Id = song.Id, Name = song.Name, Duration = song.Duration}
                                )
                            }).ToList()
                    })
                .FirstOrDefaultAsync(x => x.Id == artist.Id);
        }
    }
}