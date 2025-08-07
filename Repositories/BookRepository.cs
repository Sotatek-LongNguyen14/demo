using Demo.DTOs;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories;

public class BookRepository : IBookRepository {
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext context) {
        _dbContext = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync() {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<BookResponseDto?> GetBookDtoByIdAsync(int id) {
        var book = await _dbContext.Books
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author)
            .Include(b => b.Publisher)
            .Where(b => b.Id == id)
            .Select(b => new BookResponseDto {
                Id = b.Id,
                Title = b.Title,
                PublishYear = b.PublishYear,
                ISBN = b.ISBN,
                PublisherId = b.PublisherId,
                PublisherName = b.Publisher.Name,
                Authors = b.BookAuthors.Select(ba => ba.Author.Name).ToList(),
            })
            .FirstOrDefaultAsync();

        return book;
    }

    public async Task AddAsync(Book book) {
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var book = await _dbContext.Books.FindAsync(id);
        if (book != null) {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<Book?> GetBookByIdAsync(int id) {
        return await _dbContext.Books.FindAsync(id);
    }
    
    public async Task<bool> ExistsAsync(int id) {
        return await _dbContext.Books.AnyAsync(b => b.Id == id);
    }
}