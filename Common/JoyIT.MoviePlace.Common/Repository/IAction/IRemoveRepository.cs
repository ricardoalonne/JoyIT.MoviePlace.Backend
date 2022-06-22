using System.Threading.Tasks;

namespace JoyIT.MoviePlace.Common.Repository.IAction
{
    public interface IRemoveRepository<T>
    {
        Task Remove(T id);
    }
}
