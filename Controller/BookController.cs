using Microsoft.EntityFrameworkCore;

namespace Demo.Controller;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase {
    private readonly ApplicationDbContext _context;

    public BookController(ApplicationDbContext context) {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks() {
        return await _context.Books.ToListAsync();
    } 
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookById(int id) {
        var book = await _context.Books.FindAsync(id);

        if (book == null) {
            return NotFound();
        }

        return book;
    }
    
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(Book book) {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id) {
        var book = await _context.Books.FindAsync(id);

        if (book == null) {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}