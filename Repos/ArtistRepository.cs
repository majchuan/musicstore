using Microsoft.EntityFrameworkCore;

public class Artistrepository : GenericRepository<Artist>, IArtistRepository
{
    private ApplicationContext _ac;
    public Artistrepository(ApplicationContext a_c) : base(a_c){
         this._ac = a_c;
    }
    public Boolean ValidateArtist(Artist artist){
        return true;
    }

}