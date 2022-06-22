using JoyIT.MoviePlace.Context;
using JoyIT.MoviePlace.UnitOfWork.Interface;

namespace JoyIT.MoviePlace.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkAdapter(_context);
        }
    }
}
