public class Album : BaseModel
{
    public string Name{get;set;}
    public int YearRelease{get;set;}
    public virtual ICollection<Song> Songs{get;set;}

    public long ArtistId{get;set;}
    public virtual Artist Artist {get;set;}
}