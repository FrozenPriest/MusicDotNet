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
            //DataAccess <-> Domain
            CreateMap<DataAccess.Entities.Song, Domain.Song>();
            CreateMap<DataAccess.Entities.Album, Domain.Album>();
            CreateMap<DataAccess.Entities.Artist, Domain.Artist>();
            //Domain <-> DTO
            CreateMap<Domain.Song, SongDTO>();
            CreateMap<Domain.Album, AlbumDTO>();
            CreateMap<Domain.Artist, ArtistDTO>();
            //ActionDTO <-> Domain UpdateModel
            CreateMap<SongCreateDTO, SongUpdateModel>();
            CreateMap<SongUpdateDTO, SongUpdateModel>();
            CreateMap<AlbumCreateDTO, AlbumUpdateModel>();
            CreateMap<AlbumUpdateDTO, AlbumUpdateModel>();
            CreateMap<ArtistCreateDTO, ArtistUpdateModel>();
            CreateMap<ArtistUpdateDTO, ArtistUpdateModel>();
            //UpdateModel <-> DataAccess
            CreateMap<SongUpdateModel, DataAccess.Entities.Song>();
            CreateMap<AlbumUpdateModel, DataAccess.Entities.Album>();
            CreateMap<ArtistUpdateModel, DataAccess.Entities.Artist>();
        }
    }
}