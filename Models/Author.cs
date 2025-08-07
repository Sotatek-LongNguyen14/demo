namespace Demo.Models;

public class Author {
    public int  Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int DateOfBirth { get; set; }
    public string Address { get; set; } = null!;
    
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}