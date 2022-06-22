using System.Collections.Generic;
using System.Threading.Tasks;

namespace JoyIT.MoviePlace.Common.Service
{
    public interface IService<TResponse, TRequest> where TResponse : class
    {
        Task<List<TResponse>> GetAll();

        Task<List<TResponse>> Get();
        Task<TResponse> Get(int id);

        Task<bool> Post(TRequest requestModel);

        Task<bool> Put(TRequest requestModel);

        Task<bool> Delete(int id);

    }
}
