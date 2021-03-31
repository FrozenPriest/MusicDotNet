namespace RazorWebApplication.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public AlbumModel Album { get; set; }
    }
}