using JoyIT.MoviePlace.Context;
using JoyIT.MoviePlace.Repository.Implementation;
using JoyIT.MoviePlace.Repository.Interface;
using JoyIT.MoviePlace.UnitOfWork.Interface;

namespace JoyIT.MoviePlace.UnitOfWork.Implementation
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IMovieRepository IMovieRepository { get; }
        public IMovieCategoryRepository IMovieCategoryRepository { get; }

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            IMovieRepository = new MovieRepository(context);
            IMovieCategoryRepository = new MovieCategoryRepository(context);
        }

    }
}
