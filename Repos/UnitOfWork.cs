
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _ac;
    private IArtistRepository artistRepository;
    private IAlbumRepository albumRepository;
    private ISongRepository songRepository;

    public UnitOfWork(ApplicationContext ac){
        this._ac = ac;
        this.artistRepository = new Artistrepository(ac);
        this.albumRepository = new AlbumRepository(ac);
        this.songRepository = new SongRepository(ac);
    }

    public IArtistRepository ArtistRepository{
        get{
            return artistRepository;
        }
    }

    public IAlbumRepository AlbumRepository{
        get{
            return albumRepository;
        }
    }
    public ISongRepository SongRepository{
        get{
            return songRepository;
        }
    }

    public void Save()
    {
        _ac.SaveChanges();
    }
    public void Dispose()
    {
        _ac.Dispose();
    }
}