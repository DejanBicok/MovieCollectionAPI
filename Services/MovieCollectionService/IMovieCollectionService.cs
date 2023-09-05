using Microsoft.AspNetCore.Mvc;

namespace MovieCollectionAPI.Services.UserMoviesService
{
    public interface IMovieCollectionService
    {
        Task<IEnumerable<Models.UserMovies>> Search(string name);
        Task<List<Models.UserMovies>> GetAllMovies();
        Task<Models.UserMovies?> GetSingleMovie(int id);
        Task<List<Models.UserMovies>> AddMovie(Models.UserMovies movie);
        Task<List<Models.UserMovies>?> UpdateMovie(int id, Models.UserMovies request);
        Task<List<Models.UserMovies>?> DeleteMovie(int id);
        Task<ActionResult<List<Models.UserMovies>>> GetUserMovies();
        void GetMovieByIdAsync(int movieIdToUpdate);
        bool IsUserOwnerOfCollection(string userId, string? resourceId);
        Task GetMovieById(int id);
        Task GetMoviesByUserId(string? userId);
        Task UserAddMovie(UserMovies movie);
        Task<bool> UserExists(int id);
    }
}
