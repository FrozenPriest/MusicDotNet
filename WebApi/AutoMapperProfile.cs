using AutoMapper;
using Client.DTO.Read;
using Client.Requests.Create;
using Client.Requests.Update;
using Domain.Models;

namespace WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataAccess.Entities.Song, Domain.Song>();
            CreateMap<DataAccess.Entities.Album, Domain.Album>();
            CreateMap<DataAccess.Entities.Artist, Domain.Artist>();

            CreateMap<Domain.Song, SongDTO>();
            CreateMap<Domain.Album, AlbumDTO>();
            CreateMap<Domain.Artist, ArtistDTO>();

            CreateMap<SongCreateDTO, SongUpdateModel>();
            CreateMap<SongUpdateDTO, SongUpdateModel>();
            CreateMap<AlbumCreateDTO, AlbumUpdateModel>();
            CreateMap<AlbumUpdateDTO, AlbumUpdateModel>();


            CreateMap<SongUpdateModel, DataAccess.Entities.Song>();
            CreateMap<AlbumUpdateModel, DataAccess.Entities.Album>();

        }
    }
}