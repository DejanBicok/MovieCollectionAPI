namespace MovieCollectionAPI.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}
