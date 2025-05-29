using E_library.Data;
using E_library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_library.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class LibrariansController : ControllerBase
{
    private readonly LibraryContext _context;

    public LibrariansController( LibraryContext context ) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Librarian>>> GetLibrarians() => await _context.Librarians.ToListAsync();

    [HttpGet( "{id}" )]
    public async Task<ActionResult<Librarian>> GetLibrarian( int id )
    {
        var librarian = await _context.Librarians.FindAsync( id );
        return librarian == null ? NotFound() : librarian;
    }

    [HttpPost]
    public async Task<ActionResult<Librarian>> CreateLibrarian( Librarian librarian )
    {
        _context.Librarians.Add( librarian );
        await _context.SaveChangesAsync();
        return CreatedAtAction( nameof( GetLibrarian ), new { id = librarian.Id }, librarian );
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateLibrarian( int id, Librarian librarian )
    {
        if ( id != librarian.Id )
            return BadRequest();
        _context.Entry( librarian ).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteLibrarian( int id )
    {
        var librarian = await _context.Librarians.FindAsync( id );
        if ( librarian == null )
            return NotFound();
        _context.Librarians.Remove( librarian );
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
