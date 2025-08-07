using Microsoft.EntityFrameworkCore;
using Demo.Models;

namespace Demo.Repositories;

public class PublisherRepository : IPublisherRepository {
    private readonly ApplicationDbContext _context;

    public PublisherRepository(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Publisher>> GetAllPublishersAsync() {
        return await _context.Publishers.ToListAsync();
    }

    public async Task<Publisher?> GetPublisherByIdAsync(int id) {
        return await _context.Publishers.FindAsync(id);
    }

    public async Task AddPublisherAsync(Publisher publisher) {
        _context.Publishers.Add(publisher);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePublisherAsync(int id) {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher != null) {
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
        }
    }
}