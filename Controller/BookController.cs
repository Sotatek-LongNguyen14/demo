using Demo.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controller;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase {
    private readonly IBookRepository _bookRepository;
    public BookController(IBookRepository bookRepository) {
        _bookRepository = bookRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks() {
        return Ok(await _bookRepository.GetAllAsync());
    } 
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookById(int id) {
        var book = await _bookRepository.GetBookDtoByIdAsync(id);

        if (book == null) {
            return NotFound();
        }

        return Ok(book);
    }
    
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(BookCreationDto bookCreationDto) {
        var book = new Book() {
            Title = bookCreationDto.Title,
            AuthorId = bookCreationDto.AuthorId,
            PublishYear = bookCreationDto.PublishYear,
            ISBN = bookCreationDto.ISBN,
            PublisherId = bookCreationDto.PublisherId,
        };
        
        await _bookRepository.AddAsync(book);

        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id) {
        var book = await _bookRepository.GetBookByIdAsync(id);

        if (book == null) {
            return NotFound();
        }

        await _bookRepository.DeleteAsync(id);

        return NoContent();
    }
}