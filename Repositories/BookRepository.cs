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

    public async Task<Book?> GetByIdAsync(int id) {
        return await _dbContext.Books.FindAsync(id);
    }

    public async Task AddAsync(Book book) {
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var book = await GetByIdAsync(id);
        if (book != null) {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
    
    public async Task<bool> ExistsAsync(int id) {
        return await _dbContext.Books.AnyAsync(b => b.Id == id);
    }
}