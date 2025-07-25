using Microsoft.EntityFrameworkCore;
using VideoGameExample.Models;

namespace VideoGameExample.Data;

public class VideoGamesDbContext(DbContextOptions<VideoGamesDbContext> options) : DbContext(options)
{
    public DbSet<VideoGame> VideoGames => Set<VideoGame>();
}