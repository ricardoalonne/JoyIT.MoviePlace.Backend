using JoyIT.MoviePlace.Repository.Interface;

namespace JoyIT.MoviePlace.UnitOfWork.Interface
{
    public interface IUnitOfWorkRepository
    {
        IMovieRepository IMovieRepository { get; }
        IMovieCategoryRepository IMovieCategoryRepository { get; }
    }
}
