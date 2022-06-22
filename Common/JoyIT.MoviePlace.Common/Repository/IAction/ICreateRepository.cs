using System.Threading.Tasks;

namespace JoyIT.MoviePlace.Common.Repository.IAction
{
    public interface ICreateRepository<T> where T : class
    {
        Task Create(T t);
    }
}
