using Demo.Models;

namespace Demo.Repositories;

public interface IPublisherRepository {
   Task<IEnumerable<Publisher>> GetAllPublishersAsync(); 
   Task<Publisher?> GetPublisherByIdAsync(int id);
   Task AddPublisherAsync(Publisher publisher);
   Task DeletePublisherAsync(int id);
}