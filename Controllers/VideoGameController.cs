using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VideoGameExample.Models;

namespace VideoGameExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameController : ControllerBase
{
    static private List<VideoGame> videoGames = new List<VideoGame> {
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
         Id   = 4,
         Title = "Grand Theft Auto V",
         Platform = "PC",
         Developer = "Rockstar North",
         Publisher = "Rockstar",
        }
    };

    [HttpGet]
    public ActionResult<List<VideoGame>> GetVideoGames()
    {
        return Ok(videoGames);
    }

    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<VideoGame> GetVideoGame(int id)
    {
        VideoGame? videoGame = videoGames.FirstOrDefault(v => v.Id == id);
        if(videoGame is null) return NotFound();
        
        return Ok(videoGame);
    }

    [HttpPost]
    [Route("post")]
    public ActionResult<VideoGame> PostVideoGame(VideoGame? newVideoGame)
    {
        if(newVideoGame is null) return BadRequest();
        
        newVideoGame.Id = videoGames.Max(v => v.Id) + 1;
        videoGames.Add(newVideoGame);
        return CreatedAtAction(nameof(PostVideoGame), new { id  = newVideoGame.Id}, newVideoGame);
    }

    [HttpPut("{id:int}")]
    public IActionResult PutVideoGame(int id, VideoGame newVideoGame)
    {
        var game = videoGames.FirstOrDefault(v => v.Id == id);
        if(game is null) return NotFound();
        
        game.Title = newVideoGame.Title;
        game.Platform = newVideoGame.Platform;
        game.Developer = newVideoGame.Developer;
        game.Publisher = newVideoGame.Publisher;
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteVideoGame(int id) {
        var game = videoGames.FirstOrDefault(v => v.Id == id);
        if(game is null) return NotFound();
        
        videoGames.Remove(game);
        return NoContent();
    }
}