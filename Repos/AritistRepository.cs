public class Artistrepository : GenericRepository<Artist>, IGenericRepository<Artist>
{
    public Artistrepository(ApplicationContext ac) : base(ac){
    }

    
}