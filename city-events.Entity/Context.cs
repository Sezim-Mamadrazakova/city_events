
using Microsoft.EntityFrameworkCore;
using city_events.Entity.Models;
namespace city_events.Entity;

public class Context : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Events>? Events { get; set; }
    public DbSet<Favorites>? Favorites { get; set; }
    public DbSet<City>? City { get; set; }
    public DbSet<Admin>? Admin { get; set; }
    

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Admin

        builder.Entity<Admin>().ToTable("admin");
        builder.Entity<Admin>().HasKey(x => x.Id);

        #endregion
        #region User 
        builder.Entity<User>().ToTable("user");
        builder.Entity<User>().HasKey(x => x.Id);
        builder.Entity<User>().HasOne(x => x.City)
                                    .WithMany(x => x.Users)
                                    .HasForeignKey(x => x.CityId)
                                    .OnDelete(DeleteBehavior.Cascade);


        #endregion

        #region City

        builder.Entity<City>().ToTable("city");
        builder.Entity<City>().HasKey(x => x.Id);

        #endregion

        #region Events 
        builder.Entity<Events>().ToTable("events");
        builder.Entity<Events>().HasKey(x => x.Id);
        builder.Entity<Events>().HasOne(x => x.User)
                                    .WithMany(x => x.Event)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.Cascade);


        #endregion
        #region Favorites
        builder.Entity<Favorites>().ToTable("favorites");
        builder.Entity<Favorites>().HasKey(x => x.Id);
        builder.Entity<Favorites>().HasOne(x => x.User)
                                    .WithMany(x => x.Favorite)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Favorites>().HasOne(x => x.Events)
                                    .WithMany(x => x.Favorites)
                                    .HasForeignKey(x => x.EventsId)
                                    .OnDelete(DeleteBehavior.NoAction);
        
        #endregion                                                       

        
        
        

        

       
    }
}



