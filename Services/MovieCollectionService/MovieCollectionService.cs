using Microsoft.AspNetCore.Mvc;
using MovieCollectionAPI.Models;

namespace MovieCollectionAPI.Services.UserMoviesService
{
    public class MovieCollectionService : IMovieCollectionService
    {

        private readonly DataContext context;

        public MovieCollectionService(DataContext context)
        {
            this.context = context;
        }


        public async Task<List<Models.UserMovies>> AddMovie(Models.UserMovies movie)
        {
            this.context.MovieCollections.Add(movie);
            await this.context.SaveChangesAsync();

            return await this.context.MovieCollections.ToListAsync();
        }

        public async Task<List<Models.UserMovies>?> DeleteMovie(int id)
        {
            var movie = await this.context.MovieCollections.FindAsync(id);
            if (movie == null)

                return null;

            this.context.MovieCollections.Remove(movie);
            await this.context.SaveChangesAsync();

            return await this.context.MovieCollections.ToListAsync();
        }

        public async Task<List<Models.UserMovies>> GetAllMovies()
        {
            var movies = await this.context.MovieCollections.ToListAsync();
            return movies;
        }

        public Task GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public void GetMovieByIdAsync(int movieIdToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task GetMoviesByUserId(string? userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.UserMovies?> GetSingleMovie(int id)
        {
            var movie = await this.context.MovieCollections.FindAsync(id);
            if (movie == null)

                return null;

            return movie;
        }

        public Task<ActionResult<List<Models.UserMovies>>> GetUserMovies()
        {
            throw new NotImplementedException();
        }

        public bool IsUserOwnerOfCollection(string userId, string? resourceId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.UserMovies>> Search(string name)
        {
            IQueryable<Models.UserMovies> query = this.context.MovieCollections;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Title.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<List<Models.UserMovies>?> UpdateMovie(int id, Models.UserMovies request)
        {
            var movie = await this.context.MovieCollections.FindAsync(id);
            if (movie == null)

                return null;

            movie.Title = request.Title;
            movie.Genre = request.Genre;
            movie.ReleaseDate = request.ReleaseDate;

            await this.context.SaveChangesAsync();

            return await this.context.MovieCollections.ToListAsync();
        }

        public Task UserAddMovie(UserMovies movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
