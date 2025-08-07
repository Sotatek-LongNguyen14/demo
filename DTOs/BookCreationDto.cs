namespace Demo.DTOs;

public class BookCreationDto {
    public string Title { get; set; } = null!;
    public int AuthorId { get; set; }
    public int PublishYear { get; set; }
    public string ISBN { get; set; } = null!;
    public int PublisherId { get; set; }
}