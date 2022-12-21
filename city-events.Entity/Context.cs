
using Microsoft.EntityFrameworkCore;
using city_events.Entity.Models;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace city_events.Entity;


public class Context : IdentityDbContext<User, UserRole, Guid>
{

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
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
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        builder.Entity<UserRole>().ToTable("user_roles");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");


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



