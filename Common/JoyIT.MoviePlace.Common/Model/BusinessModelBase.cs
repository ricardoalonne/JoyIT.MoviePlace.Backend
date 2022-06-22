using System.ComponentModel.DataAnnotations;

namespace JoyIT.MoviePlace.Common.Model
{
    public abstract class BusinessModelBase
    {
        [Display(Name = "Identificador", ShortName = "Identificador", Description = "Identificador")]
        public int Id { get; init; }

        [Display(Name = "¿Está Activo?", ShortName = "¿Está Activo?", Description = "Si está activo en la base de datos.")]
        public bool IsActive { get; set; }
    }
}
