using E_library.Data;
using E_library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_library.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class ReadersController : ControllerBase
{
    private readonly LibraryContext _context;

    public ReadersController( LibraryContext context ) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reader>>> GetReaders() => await _context.Readers.ToListAsync();

    [HttpGet( "{id}" )]
    public async Task<ActionResult<Reader>> GetReader( int id )
    {
        var reader = await _context.Readers.FindAsync( id );
        return reader == null ? NotFound() : reader;
    }

    [HttpPost]
    public async Task<ActionResult<Reader>> CreateReader( Reader reader )
    {
        _context.Readers.Add( reader );
        await _context.SaveChangesAsync();
        return CreatedAtAction( nameof( GetReader ), new { id = reader.Id }, reader );
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateReader( int id, Reader reader )
    {
        if ( id != reader.Id )
            return BadRequest();
        _context.Entry( reader ).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteReader( int id )
    {
        var reader = await _context.Readers.FindAsync( id );
        if ( reader == null )
            return NotFound();
        _context.Readers.Remove( reader );
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

