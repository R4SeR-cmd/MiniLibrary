namespace MiniLibrary.DAL.Entity
{
    public class UserBook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
