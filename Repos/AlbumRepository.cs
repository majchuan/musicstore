public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
{
    public AlbumRepository(ApplicationContext ac) : base(ac){
    }

    public Boolean ValidateAlbum(Album album){
        return true;
    }
}