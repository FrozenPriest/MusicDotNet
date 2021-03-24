using Client.Requests.Create;

namespace Client.Requests.Update
{
    public class ArtistUpdateDTO : ArtistCreateDTO
    {
        public int Id { get; set; }
    }
}