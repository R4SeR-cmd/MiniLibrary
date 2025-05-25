using MiniLibrary.DAL.Enums;

namespace MiniLibrary.BLL.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateOnly DateOfWriting { get; set; }
        public Genre Genre { get; set; }
        public string Author { get; set; }
    }
}
