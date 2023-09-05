using Microsoft.AspNetCore.Mvc;

namespace MovieCollectionAPI.Services.UserCollection
{
    public interface IUserMoviesService
    {
        Task<List<Models.UserMovies>> GetAllUserMovies();
        Task<Models.UserMovies?> GetSingleUserMovie(int id);
        Task<List<Models.UserMovies>> AddUserMovie(Models.UserMovies movie);
        Task<List<Models.UserMovies>?> UpdateUserMovie(int id, Models.UserMovies request);
        Task<List<Models.UserMovies>?> DeleteUserMovie(int id);
        Task<ActionResult<List<Models.UserMovies>>> GetFromUserMovies();
    }
}

