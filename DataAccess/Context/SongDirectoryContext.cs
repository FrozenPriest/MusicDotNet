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
                //todo
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}