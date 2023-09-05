namespace MovieCollectionAPI.Models
{
    public class UserMovies
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; } = new DateOnly();
        public byte[]? Image { get; set; }
        public int FkUserId { get; set; }

    }
}
