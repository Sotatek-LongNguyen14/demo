using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories;
using Demo.Models;

public class AuthorRepository :  IAuthorRepository {
    private readonly ApplicationDbContext _dbContext;

    public AuthorRepository(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync() {
        return await _dbContext.Authors.ToListAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(int id) {
        return await _dbContext.Authors.FindAsync(id);
    }

    public async Task AddAuthorAsync(Author author) {
        _dbContext.Authors.Add(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAuthorAsync(int id) {
        var author = await GetAuthorByIdAsync(id);
        if (author != null) {
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}