using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    private readonly ILogger<ArtistController> _logger;
    private AlbumRepository _albumRepo;

    public AlbumController(ApplicationContext ac, ILogger<ArtistController> logger)
    {
        _logger = logger;
        _albumRepo = new AlbumRepository(ac , new Artistrepository(ac));
    }

    [HttpGet(Name = "GetAlbum")]
    public IActionResult GetAlbums()
    {
        var artists = _albumRepo.GetAll();
        if(artists == null){
            return NotFound();
        }
       return Ok(_albumRepo.GetAll());
    }

    [HttpGet(Name="GetAlbumByArtist")]
    public IActionResult GetAlbum(Artist artist)
    {
        if(artist == null){
            return BadRequest();
        }
        return Ok(_albumRepo.GetAlbumByAritist(artist.Id)) ;
    }

    [HttpGet(Name="GetAlbumByArtistName")]
    public IActionResult GetAlbumByArtistName(string artistName)
    {
        if(artistName == null){
            return BadRequest();
        }
        return Ok(_albumRepo.GetAlbumByAritistName(artistName)) ;
    }

    public IActionResult CreateAlbum(Album album, long artistID)
    {

        return Ok(_ar.Find(x => x.Name == artist.Name)) ;
    }

    public IActionResult DeleteAlbum(int? id)
    {
        if(id == null){
            return BadRequest();
        }
        _ar.Remove(_ar.GetById(id.Value));
        return Ok() ;
    }

    public IActionResult UpdateAlbum(Artist artist)
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