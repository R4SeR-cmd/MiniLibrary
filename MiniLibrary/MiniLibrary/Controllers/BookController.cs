using Microsoft.AspNetCore.Mvc;
using MiniLibrary.BLL.DTOs;
using MiniLibrary.BLL.Services.Interfaces;

namespace MiniLibrary.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {  
           var result =  await _bookService.GetAllBooksAsync();
            if(result == null)
                return NotFound();

           return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] string id)
        {
            var result = await _bookService.GetBookByIdAsync(id);
            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] BookDto bookDto)
        {
            if(bookDto == null)
                return BadRequest();
            await _bookService.CreateBookAsync(bookDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBook([FromRoute] string id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if(book == null)
                return NotFound();

            await _bookService.DeleteBookAsync(id);
            return Ok();
        }



    }
}
