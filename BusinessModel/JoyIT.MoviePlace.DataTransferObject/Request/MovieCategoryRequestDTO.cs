using JoyIT.MoviePlace.Common.Model;
using JoyIT.MoviePlace.Common.Model.Interface;
using JoyIT.MoviePlace.Common.Model.Validation;
using JoyIT.MoviePlace.Entity;
using System.ComponentModel.DataAnnotations;

namespace JoyIT.MoviePlace.DataTransferObject.Request
{
    public class MovieCategoryRequestDTO : BusinessModelBase, IBusinessDTO<MovieCategory>, IClone<MovieCategoryRequestDTO>
    {
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracterer.")]
        [FirstCapitalLetters]
        [Blanks]
        [Display(Name = "Nombre", ShortName = "Nombre", Description = "Nombre de la Categoría de Película")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracterer.")]
        [FirstCapitalLetter]
        [Blanks]
        [Display(Name = "Descripción", ShortName = "Descripción", Description = "Descripción  de la Categoría de Película")]
        public string Description { get; set; }

        public MovieCategoryRequestDTO()
        {

        }

        public MovieCategoryRequestDTO(MovieCategory entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.IsActive = entity.IsActive;
        }

        public MovieCategory ToEntity()
        {
            return new MovieCategory()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                IsActive = this.IsActive,
            };
        }

        public MovieCategoryRequestDTO Clone(int id)
        {
            return new MovieCategoryRequestDTO()
            {
                Id = id,
                Name = this.Name,
                Description = this.Description,
                IsActive = this.IsActive,
            };
        }
    }
}
