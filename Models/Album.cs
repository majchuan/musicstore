public class Album : BaseModel
{
    public string Name{get;set;}
    public int YearRelease{get;set;}
    public ICollection<Song> Songs{get;set;}

    public Aritist Aritist {get;set;}
}