using Microsoft.EntityFrameworkCore;


namespace Chat.Database.Models

{
    public class DatabaseContext:DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<UserGroup>? UserGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options) {
           //Database.EnsureCreated(); 
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
           .HasOne<Group>(s => s.Group)
           .WithMany(g => g.Messages)
           .HasForeignKey(s => s.MessageId);

            modelBuilder.Entity<Message>()
           .HasOne<User>(s => s.User)
           .WithMany(g => g.Messages)
           .HasForeignKey(s => s.MessageId);

            modelBuilder.Entity<UserGroup>().HasKey(sc => new { sc.UserId, sc.GroupId });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(ContextInitializer.InitializeUser());
        }
    }
}