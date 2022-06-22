using JoyIT.MoviePlace.Common.Repository.IAction;
using JoyIT.MoviePlace.Entity;

namespace JoyIT.MoviePlace.Repository.Interface
{
    public interface IMovieCategoryRepository : IReadRepository<MovieCategory, int>, ICreateRepository<MovieCategory>, IUpdateRepository<MovieCategory>, IRemoveRepository<int>
    {
    }
}
