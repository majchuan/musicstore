public class Aritist : BaseModel
{
    public string Name{get;set;} 
    public ICollection<Album> Albums{get;set;}
}