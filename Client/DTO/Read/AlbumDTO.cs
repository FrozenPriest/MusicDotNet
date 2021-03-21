namespace Client.DTO.Read
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ArtistDTO Artist;
    }
}