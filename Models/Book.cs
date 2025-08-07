namespace Demo.Models;

public class Book {
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public int PublishYear { get; set; }
    public string ISBN { get; set; } = null!;
    
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;

    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}