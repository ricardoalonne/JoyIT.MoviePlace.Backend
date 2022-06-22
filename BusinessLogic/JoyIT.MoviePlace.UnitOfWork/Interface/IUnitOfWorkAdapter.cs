using System;
using System.Threading.Tasks;

namespace JoyIT.MoviePlace.UnitOfWork.Interface
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repository { get; }
        Task<int> SaveChanges();
    }
}
