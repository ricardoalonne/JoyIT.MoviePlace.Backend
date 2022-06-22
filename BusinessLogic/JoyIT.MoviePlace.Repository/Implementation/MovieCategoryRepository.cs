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
    public class MovieCategoryRepository : RepositoryBase, IMovieCategoryRepository
    {
        public MovieCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(MovieCategory movieCategory)
        {
            await _context.AddAsync(movieCategory);
        }

        public async Task<MovieCategory> Get(int id)
        {
            return await _context.MovieCategories.FindAsync(id);
        }

        public async Task<IEnumerable<MovieCategory>> Get()
        {
            var movieCategorys = await _context.MovieCategories.ToListAsync();
            movieCategorys = movieCategorys.Where(movieCategory => movieCategory.IsActive).ToList();

            return movieCategorys;
        }

        public async Task<IEnumerable<MovieCategory>> GetAll()
        {
            return await _context.MovieCategories.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var movieCategory = await _context.MovieCategories.FindAsync(id);
            movieCategory.IsActive = false;
        }

        public async Task Update(MovieCategory movieCategory)
        {
            var movieCategoryUpdate = await _context.MovieCategories.FindAsync(movieCategory.Id);
            movieCategoryUpdate.Description = movieCategory.Description;
            movieCategoryUpdate.IsActive = true;

        }
    }
}
