using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniLibrary.BLL.DTOs;
using MiniLibrary.BLL.Services.Interfaces;

namespace MiniLibrary.Controllers
{
    [ApiController]
    [Route("api/books")]
    [Authorize]
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
        public async Task<IActionResult> AddBookAsync([FromBody] CreateBookDTO createBook)
        {
            if(createBook == null)
                return BadRequest();

            var bookDto = new BookDto
            {
                Id = Guid.NewGuid().ToString(),
                DateOfWriting = createBook.DateOfWriting,
                Author = createBook.Author,
                Genre = createBook.Genre,
                Title = createBook.Title

            };
            
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

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] BookDto bookDto)
        {
            if (bookDto == null)
                return BadRequest();


            await _bookService.UpdateBookAsync(bookDto);
            return Ok();
        }


        [HttpGet("filter")]
        public async Task<IActionResult> QueryBooks([FromQuery] FilterBook filterBook)
        {
            var books = await _bookService.QueryBooksAsync(filterBook);
            return Ok(books);
        }


    }
}
