using JoyIT.MoviePlace.Common.Repository.IAction;
using JoyIT.MoviePlace.Entity;

namespace JoyIT.MoviePlace.Repository.Interface
{
    public interface IMovieRepository : IReadRepository<Movie, int>, ICreateRepository<Movie>, IUpdateRepository<Movie>, IRemoveRepository<int>
    {
    }
}
