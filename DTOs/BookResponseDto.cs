using Demo.Models;

namespace Demo.DTOs;

public class BookResponseDto {
    public int Id { get; set; }
    public string Title { get; set; }
    public int PublishYear { get; set; }
    public string ISBN { get; set; }
    public int PublisherId { get; set; }
    public string PublisherName { get; set; }
    public List<string> Authors { get; set; }
}