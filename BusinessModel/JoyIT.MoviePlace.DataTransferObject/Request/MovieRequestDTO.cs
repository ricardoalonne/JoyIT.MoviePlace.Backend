using JoyIT.MoviePlace.Common.Model;
using JoyIT.MoviePlace.Common.Model.Interface;
using JoyIT.MoviePlace.Common.Model.Validation;
using JoyIT.MoviePlace.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace JoyIT.MoviePlace.DataTransferObject.Request
{
    public class MovieRequestDTO : BusinessModelBase, IBusinessDTO<Movie>, IClone<MovieRequestDTO>
    {
        [Required(ErrorMessage = "El campo Título es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracterer.")]
        [FirstCapitalLetter]
        [Blanks]
        [Display(Name = "Título", ShortName = "Título", Description = "Título de la Película")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo Sinopsis es obligatorio.")]
        [MaxLength(400, ErrorMessage = "Máximo 400 caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracterer.")]
        [FirstCapitalLetter]
        [Blanks]
        [Display(Name = "Sinopsis", ShortName = "Sinopsis", Description = "Sinopsis de la Película")]
        public string Synopsis { get; set; }

        [Required(ErrorMessage = "El campo Sinopsis es obligatorio.")]
        [StringLength(8, ErrorMessage = "Sólo 8 caracteres.")]
        [RegularExpression(@"^(?:(?:([01]?\d|2[0-3]):)?([0-5]?\d):)?([0-5]?\d)$", ErrorMessage = "Debe ingresar una duración válida.")]
        [Blanks]
        [Display(Name = "Duración", ShortName = "Duración", Description = "Duración de la Película")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "El campo Poster es obligatorio.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracterer.")]
        [FirstCapitalLetter]
        [Blanks]
        [Display(Name = "Poster", ShortName = "Poster", Description = "Poster de la Película")]
        public string PosterUrl { get; set; }

        [Required(ErrorMessage = "El campo Trailer es obligatorio.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracterer.")]
        [FirstCapitalLetter]
        [Blanks]
        [Display(Name = "Trailer", ShortName = "Trailer", Description = "Trailer de la Película")]
        public string TrailerUrl { get; set; }

        [Required(ErrorMessage = "El campo Categoría de Película es obligatorio.")]
        [Display(Name = "Categoría", ShortName = "Categoría", Description = "Categoría de Película")]
        public int MovieCategoryId { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Lanzamiento es obligatorio.")]
        [Display(Name = "Fecha de Lanzamiento", ShortName = "Fecha de Lanzamiento", Description = "Fecha de Lanzamiento de la Película")]
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;

        public MovieRequestDTO()
        {

        }

        public MovieRequestDTO(Movie entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.Synopsis = entity.Synopsis;
            this.Duration = entity.Duration;
            this.PosterUrl = entity.PosterUrl;
            this.TrailerUrl = entity.TrailerUrl;
            this.MovieCategoryId = entity.MovieCategoryId;
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
                MovieCategoryId = this.MovieCategoryId,
                ReleaseDate = this.ReleaseDate,
                IsActive = this.IsActive,
            };
        }

        public MovieRequestDTO Clone(int id)
        {
            return new MovieRequestDTO()
            {
                Id = id,
                Title = this.Title,
                Synopsis = this.Synopsis,
                Duration = this.Duration,
                PosterUrl = this.PosterUrl,
                TrailerUrl = this.TrailerUrl,
                MovieCategoryId = this.MovieCategoryId,
                ReleaseDate = this.ReleaseDate,
                IsActive = this.IsActive,
            };
        }
    }
}
