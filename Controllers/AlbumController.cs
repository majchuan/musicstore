using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    private readonly ILogger<ArtistController> _logger;
    private readonly IUnitOfWork _unitOfWork ;

    public AlbumController(IUnitOfWork unitOfWork, ILogger<ArtistController> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet(Name = "GetAlbum")]
    public IActionResult GetAlbums()
    {
        var albums= _unitOfWork.AlbumRepository.GetAll();
        if(albums == null){
            return NotFound();
        }
       return Ok(albums);
    }

    [HttpGet("",Name="GetAlbumByArtistID")]
    public IActionResult GetAlbum(Artist artist)
    {
        if(artist == null){
            return BadRequest();
        }
        return Ok(_unitOfWork.ArtistRepository.GetById(artist.Id).Albums) ;
    }

    [HttpGet(Name="GetAlbumByName")]
    public IActionResult GetAlbumByName(string albumName)
    {
        if(albumName == null){
            return BadRequest();
        }
        return Ok(_unitOfWork.AlbumRepository.Find(x => x.Name == albumName)) ;
    }

    [HttpGet(Name="GetSongsByAlbumId")]
    public IActionResult GetSongsByAlbumId(long id)
    {
        var album = _unitOfWork.AlbumRepository.GetById(id);

        return Ok(album.Songs);
    }

    [HttpGet(Name="GetSongsByAlbumName")]
    public IActionResult GetSongsByAlbumId(string name)
    {
        var albums = _unitOfWork.AlbumRepository.Find(x => x.Name == name);
        if(albums == null){
            return BadRequest();
        }

        var songs = new List<Song>();
        foreach(var album in albums){
            songs.AddRange(album.Songs);
        }
        return Ok(songs);
    }

    [HttpPost(Name="CreateAlbum")]
    public IActionResult CreateAlbum(Album album)
    {
        if(album == null || _unitOfWork.AlbumRepository.ValidateAlbum(album) == false){
            return BadRequest();
        }
        
        /*
        var artist = album.Artist ;
        if(artist == null){
            artist = _unitOfWork.AlbumRepository.GetById(album.Id).Artist;
            if(artist ==  null){
                return BadRequest();
            }
        }
        artist.Albums.Add(album);
        _unitOfWork.Save();
    */
        //return Ok(_unitOfWork.ArtistRepository.GetById(artist.Id).Albums) ;
        return Ok();
    }

    [HttpDelete(Name ="DeleteAlbum")]
    public IActionResult DeleteAlbum(Album album)
    {
        if(album == null){
            return BadRequest();
        }
        _unitOfWork.AlbumRepository.Remove(album);
        _unitOfWork.Save();
        return Ok() ;
    }

    [HttpPut(Name ="UpdateAlbum")]
    public IActionResult UpdateAlbum(Album album)
    {
        if(album == null || _unitOfWork.AlbumRepository.ValidateAlbum(album) == false){
            return BadRequest();
        }
        var albumToUpdate = _unitOfWork.AlbumRepository.GetById(album.Id);
        if(albumToUpdate == null){
            return BadRequest();
        }
        /*
        albumToUpdate.Artist = album.Artist;
        albumToUpdate.YearRelease = album.YearRelease;
        albumToUpdate.Name = album.Name;
        albumToUpdate.Songs = album.Songs;
        albumToUpdate.Artist = album.Artist;
        albumToUpdate.Created = album.Created;
        albumToUpdate.LastModified = System.DateTime.Now;
        _unitOfWork.Save();
        */
        return Ok(_unitOfWork.AlbumRepository.GetById(album.Id));
    }

}