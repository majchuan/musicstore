public interface IAlbumRepository :IGenericRepository<Album>
{
    Boolean ValidateAlbum(Album album);
}