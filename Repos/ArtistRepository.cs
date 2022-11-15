public class Artistrepository : GenericRepository<Artist>, IArtistRepository
{
    public Artistrepository(ApplicationContext ac) : base(ac){
    }
    
}