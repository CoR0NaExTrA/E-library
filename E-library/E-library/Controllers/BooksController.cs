using E_library.Data;
using E_library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_library.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class BooksController : ControllerBase
{
    private readonly LibraryContext _context;

    public BooksController( LibraryContext context ) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks() => await _context.Books
        .Include( b => b.Author )
        .Include( b => b.Genre )
        .Include( b => b.Publisher )
        .ToListAsync();

    [HttpGet( "{id}" )]
    public async Task<ActionResult<Book>> GetBook( int id )
    {
        var book = await _context.Books
            .Include( b => b.Author )
            .Include( b => b.Genre )
            .Include( b => b.Publisher )
            .FirstOrDefaultAsync( b => b.BookID == id );
        return book == null ? NotFound() : book;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook( Book book )
    {
        _context.Books.Add( book );
        await _context.SaveChangesAsync();
        return CreatedAtAction( nameof( GetBook ), new { id = book.BookID }, book );
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateBook( int id, Book book )
    {
        if ( id != book.BookID )
            return BadRequest();
        _context.Entry( book ).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteBook( int id )
    {
        var book = await _context.Books.FindAsync( id );
        if ( book == null )
            return NotFound();
        _context.Books.Remove( book );
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
