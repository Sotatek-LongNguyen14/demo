using Demo.Models;

namespace Demo.Repositories;

public interface IAuthorRepository {
    Task<IEnumerable<Author>> GetAllAuthorsAsync();
    Task<Author?> GetAuthorByIdAsync(int id);
    Task AddAuthorAsync(Author author);
    Task DeleteAuthorAsync(int id);
}