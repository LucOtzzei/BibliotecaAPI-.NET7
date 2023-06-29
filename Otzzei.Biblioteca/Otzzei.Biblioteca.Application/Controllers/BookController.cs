using Microsoft.AspNetCore.Mvc;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Requests;

namespace Otzzei.Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookAsync(BookRequest request)
        {
            var response = await _bookService.CreateBookAsync(request);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute]Guid Id, [FromBody]BookRequest request)
        {
            var response = await _bookService.UpdateBookAsync(Id, request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var response = await _bookService.GetBookByIdAsync(id);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await _bookService.GetAllBooksAsync();
            return Ok(response);
        }
    }
}
