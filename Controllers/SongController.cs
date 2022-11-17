using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    private readonly ILogger<ArtistController> _logger;
    private readonly IUnitOfWork _unitOfWork ;

    public SongController(IUnitOfWork unitOfWork, ILogger<ArtistController> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("/songs",Name = "GetSongs")]
    public IActionResult GetSongs()
    {
        var songs = _unitOfWork.SongRepository.GetAll();
        if(songs == null){
            return NotFound();
        }
       return Ok(songs);
    }

     [HttpGet("/song/{songID}",Name="GetSongByID")]
    public IActionResult GetSongByTrack(int? songID)
    {
        return Ok(_unitOfWork.SongRepository.GetById(songID.Value)) ;
    }

    [HttpGet("/song/{track}",Name="GetSongByTrack")]
    public IActionResult GetSongByTrack(int track)
    {
        return Ok(_unitOfWork.SongRepository.GetById(track)) ;
    }

    [HttpGet("/song/{songName}",Name="GetSongByName")]
    public IActionResult GetSongByName(string songName)
    {
        if(songName == null){
            return BadRequest();
        }
        return Ok(_unitOfWork.SongRepository.Find(x => x.Name == songName)) ;
    }
    [HttpPost("/song",Name="CreateSong")]
    public IActionResult CreateSong(Song song)
    {
        if(song == null || song.Album == null){
            return BadRequest();
        }
        var album = _unitOfWork.AlbumRepository.GetById(song.Album.Id);
        if(album == null){
            return BadRequest();
        }
        if(_unitOfWork.SongRepository.ValidateSong(song) == false){
            return BadRequest();
        }
        album.Songs.Add(song);
        
        _unitOfWork.Save();

        return Ok(_unitOfWork.SongRepository.Find(x => x.Name == song.Name)) ;
    }

    [HttpDelete("/song",Name ="DeleteSong")]
    public IActionResult DeleteSong(Song song)
    {
        if(song == null){
            return BadRequest();
        }
        _unitOfWork.SongRepository.Remove(song);
        _unitOfWork.Save();
        return Ok() ;
    }

    [HttpPut("/song",Name ="UpdateSong")]
    public IActionResult UpdateSong(Song song)
    {
        var songToUpdate = _unitOfWork.SongRepository.GetById(song.Id);
        if(songToUpdate == null){
            return BadRequest();
        }
        songToUpdate.Album = song.Album;
        songToUpdate.Created = song.Created;
        songToUpdate.LastModified = System.DateTime.Now;
        songToUpdate.Name = song.Name;
        songToUpdate.Track = song.Track;
        _unitOfWork.Save();

        return Ok(_unitOfWork.SongRepository.GetById(song.Id));
    }

}