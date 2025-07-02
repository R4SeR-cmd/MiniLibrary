namespace MiniLibrary.DAL.Entity
{
    public class UserBook
    {
        public string Id { get; set; } = Guid .NewGuid().ToString();
        public string UserId { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
