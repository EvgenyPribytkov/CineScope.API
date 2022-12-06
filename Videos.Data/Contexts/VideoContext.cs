using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Videos.Data.Entities;

namespace Videos.Data.Contexts
{
    public class VideoContext : DbContext
    {
        public DbSet<Film> Films => Set<Film>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Producer> Producers => Set<Producer>();
        public DbSet<FilmGenre> FilmGenres =>
        Set<FilmGenre>();
        public VideoContext(DbContextOptions<VideoContext> options)
: base(options) { }
            protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<FilmGenre>().HasKey(fg =>
new { fg.FilmId, fg.GenreId });
        }
    }
}

