public class Artistrepository : GenericRepository<Artist>, IArtistRepository
{
    public Artistrepository(ApplicationContext ac) : base(ac){
    }

    public Boolean ValidateArtist(Artist artist){
        return true;
    }
    
}