using Microsoft.AspNetCore.Mvc;
using SES.Data.Repositories.Common;
using SES.Domain.Entities;

namespace SES.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;
    
    public BooksController(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var persons = await _booksRepository.GetAllAsync();
        return Ok(persons);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Book person)
    {
        await _booksRepository.InsertAsync(person);
        return Ok(person);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _booksRepository.DeleteAsync(id);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Book person)
    {
        await _booksRepository.UpdateAsync(person);
        return Ok(person);
    }
}