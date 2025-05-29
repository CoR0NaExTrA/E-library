namespace E_library.Models;

public class Reader
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public string? ContactInfo { get; set; }

    public DateTime? RegistrationDate { get; set; } = DateTime.UtcNow;

    public byte[]? Photo { get; set; } 
}
