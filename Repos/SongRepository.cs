public class SongRepository : GenericRepository<Song>, IGenericRepository<Song>
{
    public SongRepository(ApplicationContext ac) : base(ac){
        
    }
}