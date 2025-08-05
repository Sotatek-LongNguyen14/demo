using Demo.Models;

namespace Demo.Repositories;

public interface IBookRepository {
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task AddAsync(Book book);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}