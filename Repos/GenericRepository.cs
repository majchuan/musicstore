public class GenericRepository<T> : IGenericRepository<T>  where T: class
{
    private ApplicationContext ac;

    public GenericRepository(ApplicationContext ac){
        this.ac = ac ; 
    }

    public T GetById(long id)
    {
        return ac.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return ac.Set<T>().ToList();
    }

    public IEnumerable<T> Find(Func<T,bool> expression)
    {
        return ac.Set<T>().Where(expression);
    }

    public void Add(T t)
    {
        ac.Set<T>().Add(t);
    }

    public void AddRange(IEnumerable<T> t)
    {
        ac.Set<T>().AddRange(t);
    }

    public void Remove(T t)
    {
        ac.Set<T>().Remove(t);
    }

    public void RemoveRange(IEnumerable<T> t)
    {
        ac.Set<T>().RemoveRange(t);
    }
}