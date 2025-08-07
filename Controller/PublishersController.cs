using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.Models;
using Demo.Repositories;
using Demo.DTOs;

namespace Demo.Controller;

[Route("api/[controller]")]
[ApiController]
public class PublishersController : ControllerBase {
    private readonly IPublisherRepository _publisherRepository;

    public PublishersController(IPublisherRepository publisherRepository) {
        _publisherRepository = publisherRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Publisher>>> GetAllPublishers() {
        return Ok(await _publisherRepository.GetAllPublishersAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Publisher>> GetPublisherById(int id) {
        var publisher = await _publisherRepository.GetPublisherByIdAsync(id);

        if (publisher == null) {
            return NotFound();
        }

        return publisher;
    }

    [HttpPost]
    public async Task<ActionResult<Publisher>> AddPublisher(PublisherCreationDto publisherCreationDto) {
        var publisher = new Publisher() {
            Name = publisherCreationDto.Name,
            Email = publisherCreationDto.Email,
            Phone = publisherCreationDto.Phone,
            Location = publisherCreationDto.Location,
        };
        
        await _publisherRepository.AddPublisherAsync(publisher);
        return CreatedAtAction(nameof(GetPublisherById), new { id = publisher.Id }, publisher);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Publisher>> DeletePublisherById(int id) {
        var publisher = await _publisherRepository.GetPublisherByIdAsync(id);
        if (publisher == null) {
            return  NotFound();
        }

        await _publisherRepository.DeletePublisherAsync(id);
        return NoContent();
    }
}