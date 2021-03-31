namespace RazorWebApplication.Models
{
    public class SongUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int AlbumId { get; set; }
    }
}