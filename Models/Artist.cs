public class Artist : BaseModel
{
    public string Name{get;set;} 
    public virtual ICollection<Album> Albums{get;set;}

    //public Boolean Active{get;set;}
}