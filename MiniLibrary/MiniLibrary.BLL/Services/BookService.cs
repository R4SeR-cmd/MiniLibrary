using Microsoft.EntityFrameworkCore;
using MiniLibrary.BLL.DTOs;
using MiniLibrary.BLL.Extensions;
using MiniLibrary.BLL.Services.Interfaces;
using MiniLibrary.DAL.UnitOfWorks.Interfaces;

namespace MiniLibrary.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BookDto> GetBookByIdAsync(string id)
        {
            
            var result =  await _unitOfWork.Books.GetAsync(id);
            return  result.ToDto();
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var result = await _unitOfWork.Books.GetAllAsync();
            return result.Select(x => x.ToDto()).ToList();
            
        }

        public async Task DeleteBookAsync(string id)
        {
            var book = await _unitOfWork.Books.GetAsync(id);
            if(book == null)
                return;

            _unitOfWork.Books.Delete(book);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<BookDto> CreateBookAsync(BookDto book)
        {
            if (book == null)
                return null;
             
            await _unitOfWork.Books.AddAsync(book.ToEntity());
            await _unitOfWork.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBookAsync(BookDto book)
        {   
            _unitOfWork.Books.Update(book.ToEntity());
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<List<BookDto>> QueryBooksAsync(FilterBook filter)
        {
            var query = _unitOfWork.Books.GetAllAsQueryable()
                .ApplyFilter(filter)
                .ApplyPages(filter.Page,filter.PageSize)
                .Select(x => x.ToDto());

            return await query.ToListAsync();
        }
    }
}
