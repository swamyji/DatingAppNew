using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserLike> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

             builder.Entity<UserLike>()
                .HasKey(k => new { k.SourceUserId, k.LikedUserId }); //

            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserLike>()
                .HasOne(s => s.LikedUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.LikedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        //In .NET 5 < and .NET Core 2.0 < you can use .OnDelete(DeleteBehavior.Restrict) in OnModelCreating like @Nexus23 answer but you do not need to disable cascade for every model.
         
    }
}