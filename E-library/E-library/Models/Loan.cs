using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_library.Models;

public class Loan
{
    [Key]
    public int LoanID { get; set; }

    [Required]
    public int ReaderID { get; set; }

    [Required]
    public int BookID { get; set; }

    [Required]
    [Column( TypeName = "date" )]
    public DateTime LoanDate { get; set; } = DateTime.UtcNow.Date;

    [Column( TypeName = "date" )]
    public DateTime? ReturnDate { get; set; }

    [Required]
    [MaxLength( 50 )]
    public string Status { get; set; } = "выдана";

    // Навигационные свойства (если используешь)
    public Reader? Reader { get; set; }
    public Book? Book { get; set; }
}
