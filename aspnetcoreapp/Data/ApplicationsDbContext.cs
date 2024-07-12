using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    } 

    // Define DbSet properties for each entity
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the relationships between entities

        // Configure Transaction entity
        modelBuilder.Entity<Transaction>()
            .HasKey(t => t.Id); // Primary key configuration

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.User) // Every transaction has one user
            .WithMany(u => u.Transactions) // User has many transactions
            .HasForeignKey(t => t.UserId) // Foreign key to UserId in Transaction
            .OnDelete(DeleteBehavior.Restrict); // Do not cascade delete

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Category) // Every transaction has one category
            .WithMany(c => c.Transactions) // Category has many transactions
            .HasForeignKey(t => t.CategoryId) // Foreign key to CategoryId in Transaction
            .OnDelete(DeleteBehavior.Restrict); // Do not cascade delete

        // Configure Report entity
        modelBuilder.Entity<Report>()
            .HasKey(r => r.Id); // Primary key configuration

        modelBuilder.Entity<Report>()
            .HasOne(r => r.User) // Every report has one user
            .WithMany(u => u.Reports) // User has many reports
            .HasForeignKey(r => r.UserId) // Foreign key to UserId in Report
            .OnDelete(DeleteBehavior.Restrict); // Do not cascade delete

        modelBuilder.Entity<Report>()
            .HasMany(r => r.Transaction) // Every report has many transactions
            .WithMany(t => t.Reports) // Transaction has many reports
            .HasForeignKey(r => r.TransactionId) // Foreign key to TransactionId in Report
            .OnDelete(DeleteBehavior.Restrict); // Do not cascade delete

        // Configure User entity
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id); // Primary key configuration

        modelBuilder.Entity<User>()
            .HasMany(u => u.Reports) // User has many reports
            .WithOne(r => r.User) // Report belongs to one user
            .HasForeignKey(r => r.UserId) // Foreign key to UserId in Report
            .OnDelete(DeleteBehavior.Restrict); // Do not cascade delete

        // Configure Category entity
        modelBuilder.Entity<Category>()
            .HasKey(c => c.Id); // Primary key configuration
    }
}
