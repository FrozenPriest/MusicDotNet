namespace Client.DTO.Read
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        public AlbumDTO Album { get; set; }
    }
}