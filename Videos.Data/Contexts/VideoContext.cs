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
        public DbSet<Director> Directors =>
        Set<Director>();
        public DbSet<FilmGenre> FilmGenres =>
        Set<FilmGenre>();
        public DbSet<FilmDirector> FilmDirector =>
        Set<FilmDirector>();
        public VideoContext(DbContextOptions<VideoContext> options)
: base(options) { }
            protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<FilmGenre>().HasKey(fg =>
new { fg.FilmId, fg.GenreId });
            builder.Entity<FilmDirector>().HasKey(fd =>
new { fd.FilmId, fd.DirectorId });

            SeedData(builder);
        }
        private void SeedData(ModelBuilder builder)
        {
            var producers = new List<Producer>
            {
                new Producer
                {
                    Id = 1,
                    Name = "20th Century Fox",
                },
                new Producer
                {
                    Id = 2,
                    Name = "Warner",
                }
            };
            builder.Entity<Producer>().HasData(producers);
            var films = new List<Film>
            { 
                new Film
                {
                    Id = 1,
                    Title = "Alien",
                    Released = new DateTime(1979, 05, 25),
                    ProducerId = 1
                },
                new Film
                {
                    Id = 2,
                    Title = "Matrix",
                    Released = new DateTime(2019, 03, 24),
                    ProducerId = 2,
                }
            };
            builder.Entity<Film>().HasData(films);
            var genres = new List<Genre>
            {
                new Genre
                {
                    Id = 1,
                    Name = "Horror",
                },
                new Genre
                {
                    Id = 2,
                    Name = "Science Fiction",
                }
            };
            builder.Entity<Genre>().HasData(genres);
            var filmgenres = new List<FilmGenre>
            {
                new FilmGenre
                {
                    FilmId = 1,
                    GenreId = 1,
                },
                new FilmGenre
                {
                    FilmId = 1,
                    GenreId = 2,
                },
                new FilmGenre
                {
                    FilmId = 2,
                    GenreId = 2,
                },
            };
            builder.Entity<FilmGenre>().HasData(filmgenres);
            var directors = new List<Director>
            {
                new Director
                {
                    Id = 1,
                    Name = "Ridley Scott",
                },
                new Director
                {
                    Id = 2,
                    Name = "Lana Wachowski",
                },
                new Director
                {
                    Id = 3,
                    Name = "Lilly Wachowski",
                }
            };
            builder.Entity<Director>().HasData(directors);
            var filmdirectors = new List<FilmDirector>
            {
                new FilmDirector
                {
                    FilmId = 1,
                    DirectorId = 1,
                },
                new FilmDirector
                {
                    FilmId = 2,
                    DirectorId = 2,
                },
                new FilmDirector
                {
                    FilmId = 2,
                    DirectorId = 3,
                },
            };
            builder.Entity<FilmDirector>().HasData(filmdirectors);
        }
    }
}

