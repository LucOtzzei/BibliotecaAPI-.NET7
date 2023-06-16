using Microsoft.AspNetCore.Mvc;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Requests;

namespace Otzzei.Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync([FromBody]AuthorRequest request)
        {
            var result = await _authorService.CreateAuthorAsync(request);
            return CreatedAtAction("author", result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync([FromRoute]Guid id, [FromBody]AuthorRequest request)
        {
            var result = await _authorService.UpdateAuthorAsync(id, request);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync([FromRoute]Guid id)
        {
            var result = await _authorService.GetAuthorByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            var result = await _authorService.GetAllAuthorsAsync();
            return Ok(result);
        }
    }
}
