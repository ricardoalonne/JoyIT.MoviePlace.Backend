using JoyIT.MoviePlace.Context;
using JoyIT.MoviePlace.UnitOfWork.Interface;
using System.Threading.Tasks;

namespace JoyIT.MoviePlace.UnitOfWork.Implementation
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        private readonly ApplicationDbContext _context;

        public IUnitOfWorkRepository Repository { get; set; }

        public UnitOfWorkAdapter(ApplicationDbContext context)
        {
            _context = context;

            Repository = new UnitOfWorkRepository(context);
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
