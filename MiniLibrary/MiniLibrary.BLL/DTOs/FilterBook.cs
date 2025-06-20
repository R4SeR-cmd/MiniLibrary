using MiniLibrary.DAL.Enums;

namespace MiniLibrary.BLL.DTOs
{
    public class FilterBook
    {
        public string? Title { get; set; }
        public DateTime? DateOfWriting { get; set; }
        public Genre? Genre { get; set; }
        public string? Author { get; set; }
    }
}
