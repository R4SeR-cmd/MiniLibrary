using MiniLibrary.BLL.DTOs.Interfaces;
using MiniLibrary.DAL.Entity;
using MiniLibrary.DAL.Enums;

namespace MiniLibrary.BLL.DTOs
{
    public class FilterBook : IFilter<Book>
    {
        public string? Title { get; set; }
        public DateTime? DateOfWriting { get; set; }
        public Genre? Genre { get; set; }
        public string AuthorId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public IQueryable<Book> Apply(IQueryable<Book> query)
        {
            if (!string.IsNullOrWhiteSpace(AuthorId))
                query = query.Where(x => x.AuthorId == AuthorId);

            if (!string.IsNullOrWhiteSpace(Title))
                query = query.Where(x => x.Title == Title);

            if (DateOfWriting.HasValue)
                query = query.Where(x => x.DateOfWriting == DateOfWriting);

            if (Genre.HasValue)
                query = query.Where(x => x.Genre == Genre.Value);

            return query;
        }
    }
}
