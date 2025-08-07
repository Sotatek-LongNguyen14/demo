namespace Demo.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Publisher> Publishers { get; set; } = null!;
    public DbSet<BookAuthor> BookAuthors { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        // many-to-many: book <-> author
        modelBuilder.Entity<BookAuthor>()
            .HasKey(x => new { x.BookId, x.AuthorId });
        
        modelBuilder.Entity<BookAuthor>()
            .HasOne(x => x.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<BookAuthor>()
            .HasOne(x => x.Author)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // one-to-many: publisher <-> book
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // seed Publisher
        modelBuilder.Entity<Publisher>().HasData(
            new Publisher { Id = 1, Name = "Alpha Books", Location = "Hanoi", Email = "contact@alphabooks.vn", Phone = "0123456789" },
            new Publisher { Id = 2, Name = "NXB Trẻ", Location = "Ho Chi Minh City", Email = "info@nxbtre.vn", Phone = "0987654321" }
        );

        // Seed Author
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "Nguyen Nhat Anh", Email = "anh@example.com", DateOfBirth = 1955, Address = "District 1, HCMC" },
            new Author { Id = 2, Name = "To Hoai", Email = "hoai@example.com", DateOfBirth = 1920, Address = "Hanoi" }
        );

        // Seed Book
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 101, Title = "Kinh Van Hoa", AuthorId = 1, PublisherId = 1, PublishYear = 2003, ISBN = "9786041123456" },
            new Book { Id = 202, Title = "Dế Mèn Phiêu Lưu Ký", AuthorId = 2, PublisherId = 2, PublishYear = 1941, ISBN = "9786041987654" }
        );

        // Seed BookAuthor 
        modelBuilder.Entity<BookAuthor>().HasData(
            new BookAuthor { BookId = 101, AuthorId = 1 },
            new BookAuthor { BookId = 202, AuthorId = 2 },
            new BookAuthor { BookId = 101, AuthorId = 2 }
        );
    }
}