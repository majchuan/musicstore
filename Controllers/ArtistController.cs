using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
    private readonly ILogger<ArtistController> _logger;
    private Artistrepository _ar;

    public ArtistController(ApplicationContext ac, ILogger<ArtistController> logger)
    {
        _logger = logger;
        _ar = new Artistrepository(ac);
    }

    [HttpGet(Name = "GetArtists")]
    public IActionResult GetArtists()
    {
        var artists = _ar.GetAll();
        if(artists == null){
            return NotFound();
        }
       return Ok(_ar.GetAll());
    }

    [HttpGet(Name="GetArtist")]
    public IActionResult GetArtist(int? id)
    {
        if(id == null){
            return BadRequest();
        }
        return Ok(_ar.GetById(id.Value)) ;
    }

    public IActionResult CreateArtist(Artist artist)
    {
        _ar.Add(artist);
        _ar.Save();
        return Ok(_ar.Find(x => x.Name == artist.Name)) ;
    }

    public IActionResult DeleteArtist(int? id)
    {
        if(id == null){
            return BadRequest();
        }
        _ar.Remove(_ar.GetById(id.Value));
        return Ok() ;
    }

    public IActionResult UpdateAritist(Artist artist)
    {
        var artistUpdate = _ar.GetById(artist.Id);
        if(artistUpdate != null){
            artistUpdate.Name  = artist.Name;
            artistUpdate.Albums = artist.Albums;
            _ar.Save();
        }
        return Ok(_ar.GetById(artist.Id));
    }

}
