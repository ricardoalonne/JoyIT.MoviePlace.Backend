using System.Collections.Generic;
using System.Threading.Tasks;

namespace JoyIT.MoviePlace.Common.Repository.IAction
{
    public interface IReadRepository<T, Y> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get();
        Task<T> Get(Y id);
    }
}
