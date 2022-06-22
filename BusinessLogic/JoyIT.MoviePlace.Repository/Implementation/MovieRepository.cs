using JoyIT.MoviePlace.Context;
using JoyIT.MoviePlace.Entity;
using JoyIT.MoviePlace.Repository.Base;
using JoyIT.MoviePlace.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoyIT.MoviePlace.Repository.Implementation
{
    public class MovieRepository : RepositoryBase, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Movie movie)
        {
            await _context.AddAsync(movie);
        }

        public async Task<Movie> Get(int id)
        {
            var movie = await _context.Movies.Include(movie => movie.MovieCategory).FirstOrDefaultAsync(movie => movie.Id == id);
            if (movie != null) movie.MovieCategory = await _context.MovieCategories.FindAsync(movie.MovieCategory.Id);
            return movie;
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            var movies = await _context.Movies.Include(movie => movie.MovieCategory).ToListAsync();
            movies = movies.Where(movie => movie.IsActive).ToList();

            return movies;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movies.Include(movie => movie.MovieCategory).ToListAsync();
        }

        public async Task Remove(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            movie.IsActive = false;
        }

        public async Task Update(Movie movie)
        {
            var movieUpdate = await _context.Movies.FindAsync(movie.Id);
            movieUpdate.Title = movie.Title;
            movieUpdate.Synopsis = movie.Synopsis;
            movieUpdate.Duration = movie.Duration;
            movieUpdate.PosterUrl = movie.PosterUrl;
            movieUpdate.TrailerUrl = movie.TrailerUrl;
            movieUpdate.MovieCategoryId = movie.MovieCategoryId;
            movieUpdate.IsActive = true;

        }
    }
}
