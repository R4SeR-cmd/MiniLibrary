using MiniLibrary.DAL.Enums;

namespace MiniLibrary.BLL.DTOs
{
    public class CreateBookDTO
    {
        public required string Title { get; set; }
        public DateTime DateOfWriting { get; set; }
        public Genre Genre { get; set; }
        public string Author { get; set; }
    }
}
