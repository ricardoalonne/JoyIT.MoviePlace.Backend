using System.Threading.Tasks;

namespace JoyIT.MoviePlace.Common.Repository.IAction
{
    public interface IUpdateRepository<T> where T : class
    {
        Task Update(T t);
    }
}
