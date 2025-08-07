namespace Demo.DTOs;

public class AuthorCreationDto {
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int DateOfBirth { get; set; }
    public string Address { get; set; } = null!;
}