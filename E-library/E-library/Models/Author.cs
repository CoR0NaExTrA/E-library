namespace E_library.Models;

public class Author
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? Biography { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? DeathDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}