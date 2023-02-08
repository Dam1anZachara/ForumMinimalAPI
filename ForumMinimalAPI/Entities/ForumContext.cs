using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ForumMinimalAPI.Entities
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u => 
            {
                // rel 1 to 1
                u.HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);

                // rel 1 to M
                u.HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

                // rel 1 to M
                u.HasMany(u => u.Ratings)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

                u.Property(u => u.FirstName).HasColumnType("varchar(25)");
                u.Property(u => u.LastName).HasColumnType("varchar(25)");
            });

            modelBuilder.Entity<Question>(q =>
            {
                // rel 1 to M
                q.HasOne(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(u => u.UserId);

                // rel M to M
                q.HasMany(q => q.Tags)
                .WithMany(t => t.Questions);
            });

            modelBuilder.Entity<Comment>(c =>
            {
                // rel 1 to M
                c.HasMany(c => c.Ratings)
                .WithOne(r => r.Comment)
                .HasForeignKey(r => r.CommentId);
            });

            //modelBuilder.Entity<Rating>(r =>
            //{
            //    r.OnDe
            //});
        }
    }
}
