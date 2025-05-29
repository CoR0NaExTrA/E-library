using E_library.Data;
using E_library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_library.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class AuthorsController : ControllerBase
{
    private readonly LibraryContext _context;

    public AuthorsController( LibraryContext context )
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
    {
        return await _context.Authors.ToListAsync();
    }

    [HttpGet( "{id}" )]
    public async Task<ActionResult<Author>> GetAuthor( int id )
    {
        var author = await _context.Authors.FindAsync( id );
        if ( author == null )
            return NotFound();
        return author;
    }

    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor( Author author )
    {
        _context.Authors.Add( author );
        await _context.SaveChangesAsync();
        return CreatedAtAction( nameof( GetAuthor ), new { id = author.Id }, author );
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateAuthor( int id, Author author )
    {
        if ( id != author.Id )
            return BadRequest();

        _context.Entry( author ).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteAuthor( int id )
    {
        var author = await _context.Authors.FindAsync( id );
        if ( author == null )
            return NotFound();

        _context.Authors.Remove( author );
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
