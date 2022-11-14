public class AlbumRepository : GenericRepository<Album>, IGenericRepository<Album>
{
    private Artistrepository _airtistRepo;
    public AlbumRepository(ApplicationContext ac, Artistrepository ar ) : base(ac){
        _airtistRepo = ar ; 
    }

    public ICollection<Album> GetAlbumByAritist(long artistID){
        var artist = _airtistRepo.GetById(artistID);
        return artist.Albums;
    }

    public ICollection<Album> GetAlbumByAritistName(string artistName){
        var artist = _airtistRepo.Find( x => x.Name == artistName).FirstOrDefault();
        return artist.Albums;
    }
}