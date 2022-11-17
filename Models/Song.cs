public class Song : BaseModel
{
    public int Track{get;set;}
    public string Name{get;set;}
    public virtual Album Album{get;set;}
    public long AlbumId {get;set;}
}