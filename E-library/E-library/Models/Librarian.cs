namespace E_library.Models;

public class Librarian
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string? ContactInfo { get; set; }
}
