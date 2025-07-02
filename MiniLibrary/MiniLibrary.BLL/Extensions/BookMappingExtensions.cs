using MiniLibrary.BLL.DTOs;
using MiniLibrary.DAL.Entity;

namespace MiniLibrary.BLL.Extensions
{
    public static class BookMappingExtensions
    {
        public static BookDto ToDto(this Book book)
        {
            if(book == null) return null;

            return new BookDto
            {
                Author = book.Author,
                DateOfWriting = book.DateOfWriting,
                Genre = book.Genre,
                Id = book.Id,
                Title = book.Title
            };
        }

        public static Book ToEntity(this BookDto bookDto)
        {
            if(bookDto == null) return null;

            return new Book
            {
                Author = bookDto.Author,
                DateOfWriting = bookDto.DateOfWriting,
                Genre = bookDto.Genre,
                Id = bookDto.Id,
                Title = bookDto.Title
            };

        }
    }
}
