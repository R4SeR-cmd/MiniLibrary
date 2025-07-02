namespace MiniLibrary.BLL.DTOs.Interfaces
{
    public interface IFilter<T>
    {
        IQueryable<T> Apply(IQueryable<T> query);
    }
}
