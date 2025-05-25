using MiniLibrary.BLL.DTOs;

namespace MiniLibrary.BLL.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(int id);
        Task<List<BookDto>> GetAllBooksAsync();
        void DeleteBookAsync(int id);
        Task CreateBookAsync(BookDto book);
        Task UpdateBookAsync(BookDto book);

        //Filtration later
    }
}
