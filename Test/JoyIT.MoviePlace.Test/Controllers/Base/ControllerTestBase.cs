using JoyIT.MoviePlace.Context;
using Microsoft.EntityFrameworkCore;

namespace JoyIT.MoviePlace.Test.Controllers.Base
{
    public abstract class ControllerTestBase
    {
        protected ApplicationDbContext BuildContext(string connectionString)
        {
            var opciones = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(connectionString).Options;

            var context = new ApplicationDbContext(opciones);
            return context;
        }
    }
}
