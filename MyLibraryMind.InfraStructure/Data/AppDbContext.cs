using Microsoft.EntityFrameworkCore;
using MyLibraryMind.Domain.Models;
using MyLibraryMind.Domain.Models.Enums;

namespace MyLibraryMind.InfraStructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User -> Loans (1:N)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Loans)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Book -> Loans (1:N)
        modelBuilder.Entity<Book>()
            .HasMany<Loan>()
            .WithOne(l => l.Book)
            .HasForeignKey(l => l.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        // Author -> Books (1:N)
        modelBuilder.Entity<Author>().HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Enum Genre: armazenar como string no Postgres
        modelBuilder.Entity<Book>()
            .Property(b => b.Genres)
            .HasConversion(
                v => v.ToString(), 
                v => (Genre)Enum.Parse(typeof(Genre), v));
        
        // Campos obrigatórios
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired();
        
        modelBuilder.Entity<Book>()
            .Property(b => b.Name)
            .IsRequired();
        
        modelBuilder.Entity<Author>()
            .Property(a => a.Name)
            .IsRequired();
    }
}