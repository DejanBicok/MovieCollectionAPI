namespace MovieCollectionAPI.Models
{
    public class UserCollection
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; } = new DateOnly();

    }
}
