using JoyIT.MoviePlace.Common.Model;

namespace JoyIT.MoviePlace.Entity.Base
{
    public abstract class MovieCategoryBase : BusinessModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
