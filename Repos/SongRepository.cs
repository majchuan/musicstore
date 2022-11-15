public class SongRepository : GenericRepository<Song>, ISongRepository
{
    public SongRepository(ApplicationContext ac) : base(ac){
        
    }

    public Boolean ValidateSong(Song song)
    {
        return true; 
    }
}