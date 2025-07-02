using MiniLibrary.BLL.DTOs.Interfaces;

namespace MiniLibrary.BLL.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, IFilter<T> filter)
        {
            return filter.Apply(query);
        }

        public static IQueryable<T> ApplyPages<T>(this IQueryable<T> query, int page, int pageSize)
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
