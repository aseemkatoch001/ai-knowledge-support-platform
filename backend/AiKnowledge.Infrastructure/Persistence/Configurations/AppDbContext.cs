using AiKnowledge.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AiKnowledge.Infrastructure.Persistence.Configurations
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<UserRole> UserRoles => Set<UserRole>();

        public DbSet<Document> Documents => Set<Document>();

        public DbSet<DocumentChunk> DocumentChunks => Set<DocumentChunk>();

        public DbSet<Conversation> Conversations => Set<Conversation>();

        public DbSet<Message> Messages => Set<Message>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("vector");

            modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
            // Configure the UserRole entity
        }   
    }
}
