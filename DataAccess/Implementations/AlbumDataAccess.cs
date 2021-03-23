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
            return Mapper.Map<Album>(await Context.Album.Include(x =>x.Song).Include(x => x.Artist)
                .FirstOrDefaultAsync(x => x.Id == album.AlbumId));
        }

        public async Task<IEnumerable<Album>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Album>>(
                await Context.Album.Include(x =>x.Song).Include(x => x.Artist).ToListAsync());
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


        private async Task<object> Get(ISongIdentity album)
        {
            if (album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            return await Context.Album.Include(x => x.Artist)
                .FirstOrDefaultAsync(x => x.Id == album.Id);
        }
    }
}