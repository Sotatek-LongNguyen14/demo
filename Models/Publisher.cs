namespace Demo.Models;

public class Publisher {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    
    public ICollection<Book> Books { get; set; } = null!;
}