using FirstSide.Models;
using FirstSide.Models.AdminInitialize;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstSide.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<EventRestaurant> EventRestaurants { get; set; }
        public DbSet<EventClub> EventClubs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Photo> Photos { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Photo>()
                .HasOne(x => x.Restaurant)
                .WithMany(x => x.photo)
                .HasForeignKey(x => x.RestaurantId);

            builder.Entity<Photo>()
                .HasOne(x => x.Club)
                .WithMany(x => x.Photos)
                .HasForeignKey(x => x.ClubId);

            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new UsersWithRolesConfig());
                }


    }
}



