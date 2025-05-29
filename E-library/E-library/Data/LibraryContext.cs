using E_library.Models;
using Microsoft.EntityFrameworkCore;

namespace E_library.Data;

public class LibraryContext : DbContext
{
    public LibraryContext( DbContextOptions<LibraryContext> options )
        : base( options ) { }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Librarian> Librarians => Set<Librarian>();
    public DbSet<Loan> Loans => Set<Loan>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Reader> Readers => Set<Reader>();

}
