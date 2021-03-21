using Client.Requests.Create;

namespace Client.Requests.Update
{
    public class SongUpdateDTO : SongCreateDTO
    {
        public int Id { get; set; }
    }
}