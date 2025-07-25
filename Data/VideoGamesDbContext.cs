using Microsoft.EntityFrameworkCore;
using VideoGameExample.Models;

namespace VideoGameExample.Data;

public class VideoGamesDbContext(DbContextOptions<VideoGamesDbContext> options) : DbContext(options)
{
    public DbSet<VideoGame> VideoGames => Set<VideoGame>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VideoGame>().HasData(
            new VideoGame
            {
                Id = 1,
                Title = "Spiderman 2",
                Platform = "PC",
                Developer = "Insomniac Games",
                Publisher = "Sony Games Entertainment",
            },
            new VideoGame
            {
                Id = 2,
                Title = "The Legend of Zelda : Breath of the wild",
                Platform = "Nintendo Switch",
                Developer = "Nintendo EPD",
                Publisher = "Nintendo",
            },
            new VideoGame
            {
                Id = 3,
                Title = "Cyberpunk 2077",
                Platform = "PC",
                Developer = "CD Project RED",
                Publisher = "CD Project",
            },
            new VideoGame
            {
                Id = 4,
                Title = "Grand Theft Auto V",
                Platform = "PC",
                Developer = "Rockstar North",
                Publisher = "Rockstar",
            }
        );

        
    }
}