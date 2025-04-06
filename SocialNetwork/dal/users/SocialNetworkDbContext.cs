using Microsoft.EntityFrameworkCore;
using SocialNetwork.domain;

namespace SocialNetwork.dal.users
{
    public class SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("users");
                builder.HasKey(u => u.Id).HasName("users_pk");
                builder.Property(u => u.Id).HasColumnName("id");
                builder.Property(u => u.FirstName).HasColumnName("first_name").HasMaxLength(50);
                builder.Property(u => u.LastName).HasColumnName("last_name").HasMaxLength(50);
                builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(65);
                builder.HasIndex(u => u.Email).IsUnique();
                builder.Property(u => u.Birthday).HasColumnName("birthday");
                builder.Property(u => u.City).HasColumnName("city");
                builder.Property(u => u.AboutMe).HasColumnName("about_me");
                builder.Property(u => u.Sex).HasColumnName("sex");
                builder.Property(u => u.PasswordHash).HasColumnName("password_hash");
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("profiles");
                builder.HasKey(p => p.Id);
                builder.Property(u => u.Id).HasColumnName("id");
                builder.HasOne(p => p.User);
                builder.Property(p => p.UserId).HasColumnName("user_id");
            });
        }
    }
}
