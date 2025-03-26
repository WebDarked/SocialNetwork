using Microsoft.EntityFrameworkCore;
using SocialNetwork.domain;

namespace SocialNetwork.dal.users
{
    public class SocialNetworkDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("users");
                builder.HasKey(u => u.Id).HasName("users_pk");
                builder.Property(u => u.FirstName).HasMaxLength(50);
                builder.Property(u => u.LastName).HasMaxLength(50);
                builder.Property(u => u.Email).HasMaxLength(65);
                builder.HasIndex(u => u.Email).IsUnique();
            });
        }
    }
}
