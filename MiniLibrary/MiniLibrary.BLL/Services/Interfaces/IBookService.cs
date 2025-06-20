using MiniLibrary.BLL.DTOs;

namespace MiniLibrary.BLL.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(string id);
        Task<List<BookDto>> GetAllBooksAsync();
        Task DeleteBookAsync(string id);
        Task<BookDto> CreateBookAsync(BookDto book);
        Task UpdateBookAsync(BookDto book);
        Task<List<BookDto>> QueryBooksAsync(FilterBook filterBook);

    }
}
