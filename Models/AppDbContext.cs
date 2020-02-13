using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstSide.Models
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
      
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Photo> Photos { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<EventRestaurant>()
                .HasKey(k => new { k.EventId, k.RestaurantId });
            builder.Entity<EventRestaurant>()
                .HasOne(x => x.Event)
                .WithMany(x => x.EventRestaurants)
                .HasForeignKey(x => x.EventId);
            builder.Entity<EventRestaurant>()
                .HasOne(x => x.Restaurant)
                .WithMany(x => x.EventRestaurants)
                .HasForeignKey(x => x.RestaurantId);

            builder.Entity<Photo>()
                .HasOne(x => x.Restaurant)
                .WithMany(x => x.photo)
                .HasForeignKey(x => x.Restaurantid);

            
            base.OnModelCreating(builder);

        }

        
    }
}



