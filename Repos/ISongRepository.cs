public interface ISongRepository : IGenericRepository<Song>
{
    Boolean ValidateSong(Song song);
}