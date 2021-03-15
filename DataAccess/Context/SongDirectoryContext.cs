using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public partial class SongDirectoryContext : DbContext
    {
        public SongDirectoryContext()
        {
        }

        public SongDirectoryContext(DbContextOptions<SongDirectoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Duration).IsRequired();

                entity.HasOne(song => song.Album)
                    .WithMany(album => album.Song)
                    .HasForeignKey(song => song.AlbumId)
                    .HasConstraintName("FK_SONG_ALBUM");
            });
            
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(album => album.Artist)
                    .WithMany(artist => artist.Album)
                    .HasForeignKey(album => album.ArtistId)
                    .HasConstraintName("FK_ALBUM_ARTIST");
            });
            
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.Name).IsRequired();
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}