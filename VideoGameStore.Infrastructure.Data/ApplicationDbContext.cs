using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGameStore.Domain.Core.Entities;
using VideoGameStore.Infrastructure.Data.Configurations;

namespace VideoGameStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<GameGenre> GameGenres { get; set; }
       
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Company> Companies { get; set; }
        
        public DbSet<VideoGame> VideoGames { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new GameGenreConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new VideoGameConfiguration());
        }
    }
}
