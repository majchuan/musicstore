using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
    private readonly ILogger<ArtistController> _logger;
    private readonly IUnitOfWork _unitOfWork ; 

    public ArtistController(IUnitOfWork unitOfWork, ILogger<ArtistController> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet(Name = "GetArtists")]
    public IActionResult GetArtists()
    {
        var artists = _unitOfWork.ArtistRepository.GetAll();
        if(artists == null){
            return NotFound();
        }
       return Ok(artists);
    }

    [HttpGet(Name="GetArtist")]
    public IActionResult GetArtist(int? id)
    {
        if(id == null){
            return BadRequest();
        }
        return Ok(_unitOfWork.ArtistRepository.GetById(id.Value)) ;
    }

    public IActionResult GetAblumsByArtist(Artist artist)
    {
        if(artist == null){
            return BadRequest();
        }

        return Ok(_unitOfWork.ArtistRepository.GetById(artist.Id).Albums);
    }

    public IActionResult GetSongsByArtist(Artist artist)
    {
        if(artist == null){
            return BadRequest();
        }

        var albums =_unitOfWork.ArtistRepository.GetById(artist.Id).Albums;
        var songs = new List<Song>();
        foreach(var album in albums)
        {
            songs.AddRange(album.Songs);
        }

        return Ok(songs);
    }

    [HttpPost(Name="CreateArtist")]
    public IActionResult CreateArtist(Artist artist)
    {
        if(_unitOfWork.ArtistRepository.ValidateArtist(artist)== false){
            return BadRequest();
        }
        _unitOfWork.ArtistRepository.Add(artist);
        _unitOfWork.Save();
        return Ok(_unitOfWork.ArtistRepository.Find(x => x.Name == artist.Name)) ;
    }
    [HttpDelete(Name="DeleteArtist")]
    public IActionResult DeleteArtist(int? id)
    {
        if(id == null){
            return BadRequest();
        }
        _unitOfWork.ArtistRepository.Remove(_unitOfWork.ArtistRepository.GetById(id.Value));
        return Ok() ;
    }
    [HttpPut(Name="UpdateArtist")]
    public IActionResult UpdateArtist(Artist artist)
    {
        if(_unitOfWork.ArtistRepository.ValidateArtist(artist) == false){
            return BadRequest();
        }
        var artistUpdate = _unitOfWork.ArtistRepository.GetById(artist.Id);
        if(artistUpdate != null){
            artistUpdate.Name  = artist.Name;
            artistUpdate.Albums = artist.Albums;
            _unitOfWork.Save();
        }
        return Ok(_unitOfWork.ArtistRepository.GetById(artist.Id));
    }

}
