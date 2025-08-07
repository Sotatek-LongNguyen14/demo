using Demo.Models;
using Demo.DTOs;
namespace Demo.Repositories;

public interface IBookRepository {
    Task<IEnumerable<Book>> GetAllAsync();
    Task<BookDto?> GetBookDtoByIdAsync(int id);
    Task AddAsync(Book book);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<Book?> GetBookByIdAsync(int id);
}