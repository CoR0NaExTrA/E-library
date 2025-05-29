using System.ComponentModel.DataAnnotations;

namespace E_library.Models;

public class Book
{
    [Key]
    public int BookID { get; set; }

    [Required]
    [MaxLength( 255 )]
    public string Title { get; set; } = null!;

    [Required]
    public int AuthorID { get; set; }

    [Required]
    public int GenreID { get; set; }

    [Required]
    public int PublisherID { get; set; }

    [Range( 0, int.MaxValue )]
    public int Year { get; set; }

    [Range( 0, int.MaxValue )]
    public int CopiesAvailable { get; set; } = 1;

    public byte[]? CoverImage { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [MaxLength( 255 )]
    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    [MaxLength( 255 )]
    public string? UpdatedBy { get; set; }

    // Навигационные свойства
    public Author? Author { get; set; }
    public Genre? Genre { get; set; }
    public Publisher? Publisher { get; set; }
}
