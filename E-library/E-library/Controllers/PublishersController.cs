using E_library.Data;
using E_library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_library.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class PublishersController : ControllerBase
{
    private readonly LibraryContext _context;

    public PublishersController( LibraryContext context ) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers() => await _context.Publishers.ToListAsync();

    [HttpGet( "{id}" )]
    public async Task<ActionResult<Publisher>> GetPublisher( int id )
    {
        var publisher = await _context.Publishers.FindAsync( id );
        return publisher == null ? NotFound() : publisher;
    }

    [HttpPost]
    public async Task<ActionResult<Publisher>> CreatePublisher( Publisher publisher )
    {
        _context.Publishers.Add( publisher );
        await _context.SaveChangesAsync();
        return CreatedAtAction( nameof( GetPublisher ), new { id = publisher.Id }, publisher );
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdatePublisher( int id, Publisher publisher )
    {
        if ( id != publisher.Id )
            return BadRequest();
        _context.Entry( publisher ).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeletePublisher( int id )
    {
        var publisher = await _context.Publishers.FindAsync( id );
        if ( publisher == null )
            return NotFound();
        _context.Publishers.Remove( publisher );
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
