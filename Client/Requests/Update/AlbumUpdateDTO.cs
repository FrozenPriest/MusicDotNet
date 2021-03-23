using Client.Requests.Create;

namespace Client.Requests.Update
{
    public class AlbumUpdateDTO : AlbumCreateDTO
    {
        public int Id { get; set; }
    }
}