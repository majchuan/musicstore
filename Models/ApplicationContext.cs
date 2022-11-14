using Microsoft.EntityFrameworkCore;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aritist>()
        modelBuilder.Entity<Album>().HasOne(p => p.Aritist).WithMany(b => b.Albums);
        modelBuilder.Entity<Song>().HasOne(p=> p.Album).WithMany(b => b.Songs);

    }
    public DbSet<Album> Albums{get;set;}
    public DbSet<Aritist> Aritists{get;set;}
    public DbSet<Song> Songs{get;set;}

}