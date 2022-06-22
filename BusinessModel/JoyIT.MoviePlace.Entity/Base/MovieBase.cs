using JoyIT.MoviePlace.Common.Model;
using System;

namespace JoyIT.MoviePlace.Entity.Base
{
    public abstract class MovieBase : BusinessModelBase
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Duration { get; set; }
        public string PosterUrl { get; set; }
        public string TrailerUrl { get; set; }
        public int MovieCategoryId { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;
    }
}
