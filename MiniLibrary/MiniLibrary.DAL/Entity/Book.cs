using MiniLibrary.DAL.Enums;

namespace MiniLibrary.DAL.Entity
{
    public class Book
    {
        public string Id { get; set; } = Guid .NewGuid().ToString();
        public required string Title { get; set; }
        public DateTime DateOfWriting { get; set; }
        public Genre Genre { get; set; }
        public string Author { get; set; }
    }
}
