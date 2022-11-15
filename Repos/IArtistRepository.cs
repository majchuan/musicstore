public interface IArtistRepository : IGenericRepository<Artist>
{
    Boolean ValidateArtist(Artist artist);
}