using JoyIT.MoviePlace.Common.Model;
using JoyIT.MoviePlace.Common.Model.Interface;
using JoyIT.MoviePlace.Entity;
using System.ComponentModel.DataAnnotations;

namespace JoyIT.MoviePlace.DataTransferObject.Response
{
    public class MovieCategoryResponseDTO : BusinessModelBase, IBusinessDTO<MovieCategory>
    {
        [Display(Name = "Nombre", ShortName = "Nombre", Description = "Nombre de la Categoría de Película")]
        public string Name { get; set; }

        [Display(Name = "Descripción", ShortName = "Descripción", Description = "Descripción  de la Categoría de Película")]
        public string Description { get; set; }

        public MovieCategoryResponseDTO()
        {

        }

        public MovieCategoryResponseDTO(MovieCategory entity)
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
    }
}
