using JoyIT.MoviePlace.Common.Model;
using JoyIT.MoviePlace.Common.Model.Interface;
using JoyIT.MoviePlace.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace JoyIT.MoviePlace.DataTransferObject.Response
{
    public class MovieResponseDTO : BusinessModelBase, IBusinessDTO<Movie>
    {
        [Display(Name = "Título", ShortName = "Título", Description = "Título de la Película")]
        public string Title { get; set; }

        [Display(Name = "Sinopsis", ShortName = "Sinopsis", Description = "Sinopsis de la Película")]
        public string Synopsis { get; set; }

        [Display(Name = "Duración", ShortName = "Duración", Description = "Duración de la Película")]
        public string Duration { get; set; }

        [Display(Name = "Poster", ShortName = "Poster", Description = "Poster de la Película")]
        public string PosterUrl { get; set; }

        [Display(Name = "Trailer", ShortName = "Trailer", Description = "Trailer de la Película")]
        public string TrailerUrl { get; set; }

        [Display(Name = "Categoría", ShortName = "Categoría", Description = "Categoría de Película")]
        public MovieCategoryResponseDTO MovieCategory { get; set; }

        [Display(Name = "Fecha de Lanzamiento", ShortName = "Fecha de Lanzamiento", Description = "Fecha de Lanzamiento de la Película")]
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;

        public MovieResponseDTO()
        {

        }

        public MovieResponseDTO(Movie entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.Synopsis = entity.Synopsis;
            this.Duration = entity.Duration;
            this.PosterUrl = entity.PosterUrl;
            this.TrailerUrl = entity.TrailerUrl;
            this.MovieCategory = new MovieCategoryResponseDTO() { Id = entity.MovieCategoryId };
            this.ReleaseDate = entity.ReleaseDate;
            this.IsActive = entity.IsActive;
        }

        public Movie ToEntity()
        {
            return new Movie()
            {
                Id = this.Id,
                Title = this.Title,
                Synopsis = this.Synopsis,
                Duration = this.Duration,
                PosterUrl = this.PosterUrl,
                TrailerUrl = this.TrailerUrl,
                MovieCategoryId = this.MovieCategory.Id,
                ReleaseDate = this.ReleaseDate,
                IsActive = this.IsActive,
            };
        }
    }
}
