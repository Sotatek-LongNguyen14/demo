namespace Demo.Controller;

using Microsoft.EntityFrameworkCore;
using Demo.Models;
using Demo.Repositories;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase {
    private readonly IAuthorRepository _authorRepository;

    public AuthorsController(IAuthorRepository authorRepository) {
        _authorRepository = authorRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors() {
        return Ok(await _authorRepository.GetAllAuthorsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetAuthorById(int id) {
        var author = await _authorRepository.GetAuthorByIdAsync(id);

        if (author == null) {
            return NotFound();
        }

        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<Author>> PostAuthor(Author author) {
        await _authorRepository.AddAuthorAsync(author);
        return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
    }
}