using E_library.Data;
using E_library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_library.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class LoansController : ControllerBase
{
    private readonly LibraryContext _context;

    public LoansController( LibraryContext context ) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Loan>>> GetLoans() => await _context.Loans
        .Include( l => l.Book )
        .Include( l => l.Reader )
        .ToListAsync();

    [HttpGet( "{id}" )]
    public async Task<ActionResult<Loan>> GetLoan( int id )
    {
        var loan = await _context.Loans
            .Include( l => l.Book )
            .Include( l => l.Reader )
            .FirstOrDefaultAsync( l => l.LoanID == id );
        return loan == null ? NotFound() : loan;
    }

    [HttpPost]
    public async Task<ActionResult<Loan>> CreateLoan( Loan loan )
    {
        _context.Loans.Add( loan );
        await _context.SaveChangesAsync();
        return CreatedAtAction( nameof( GetLoan ), new { id = loan.LoanID }, loan );
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateLoan( int id, Loan loan )
    {
        if ( id != loan.LoanID )
            return BadRequest();
        _context.Entry( loan ).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteLoan( int id )
    {
        var loan = await _context.Loans.FindAsync( id );
        if ( loan == null )
            return NotFound();
        _context.Loans.Remove( loan );
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

