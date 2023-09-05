using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCollectionAPI.Models;
using MovieCollectionAPI.Services.UserMoviesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MovieCollectionAPI.Services.UserCollection;


namespace MovieCollectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMovieController : ControllerBase
    {
        public object UserMoviesService { get; private set; }

        private readonly Services.UserCollection.IUserMoviesService this.UserMoviesService;

        public UserMovieController(Services.UserCollection.IUserMoviesService UserMoviesService)
        {
            this.UserMoviesService = UserMoviesService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<List<UserCollection>>> GetAllUserMovies()
        {
            // Fetch movies belonging to the currently authenticated user
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var movies = await this.UserMoviesService.GetMoviesForUser(userId);
            return Ok(movies);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<UserCollection>> AddUserMovie(UserCollection movie)
        {
            // Set the user ID to the currently authenticated user
            movie.Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await this.UserMoviesService.AddUserMovie(movie);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUserMovie(int id, UserCollection request)
        {
            // Ensure the movie exists and belongs to the authenticated user
            var existingMovie = await this.UserMoviesService.GetMovieById(id);
            if (existingMovie == null || existingMovie.UserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return NotFound("Movie not found.");
            }

            var result = await this.UserMoviesService.UpdateUserMovie(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteUserMovie(int id)
        {
            // Ensure the movie exists and belongs to the authenticated user
            var existingMovie = await this.UserMoviesService.GetMovieById(id);
            if (existingMovie == null || existingMovie.UserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return NotFound("Movie not found.");
            }

            var result = await this.UserMoviesService.DeleteUserMovie(id);
            return Ok(result);
        }

        }
    }
}
