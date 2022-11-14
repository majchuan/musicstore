public class Artist : BaseModel
{
    public string Name{get;set;} 
    public ICollection<Album> Albums{get;set;}

    //public Boolean Active{get;set;}
}