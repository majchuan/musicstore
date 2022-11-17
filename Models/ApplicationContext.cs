using Microsoft.EntityFrameworkCore;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>();
        modelBuilder.Entity<Album>().HasOne(p => p.Artist).WithMany(b => b.Albums);
        modelBuilder.Entity<Song>().HasOne(p=> p.Album).WithMany(b => b.Songs);
    }
    public DbSet<Album> Albums{get;set;}
    public DbSet<Artist> Artists{get;set;}
    public DbSet<Song> Songs{get;set;}

}