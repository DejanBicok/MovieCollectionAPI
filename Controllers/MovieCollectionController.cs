using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieCollectionAPI.Services.UserMoviesService;

namespace MovieCollectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCollectionController : ControllerBase
    {
        private readonly IMovieCollectionService movieCollectionService;

        public MovieCollectionController(IMovieCollectionService movieCollectionService)
        {
            this.movieCollectionService = movieCollectionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserMovies>>> GetAllMovies()
        {
            return await this.movieCollectionService.GetAllMovies();
        }

        /* [HttpGet("{id}")]
        public async Task<ActionResult<MovieCollection>> GetSingleMovie(int id)
        {
            var result = await this.movieCollectionService.GetSingleMovie(id);
            if (result == null)
                return NotFound("Movie not found.");
            return Ok(result);
        } */

        [HttpPost, Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<UserMovies>>> AddMovie(UserMovies movie)
        {
            var result = await this.movieCollectionService.AddMovie(movie);
            return Ok(result);
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<UserMovies>>> UpdateMovie(int id, UserMovies request)
        {
            var result = await this.movieCollectionService.UpdateMovie(id, request);
            if (result == null)
                return NotFound("Movie not found.");
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<UserMovies>>> DeleteMovie(int id)
        {
            var result = await this.movieCollectionService.DeleteMovie(id);
            if (result == null)
                return NotFound("Movie not found.");
            return Ok(result);
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<UserMovies>>> Search(string search)
        {
            try
            {
                var result = await this.movieCollectionService.Search(search);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound("Movie not found. Try with another name.");
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database.");
            }
        }
    }
}
