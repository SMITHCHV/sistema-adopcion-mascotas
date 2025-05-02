using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SistemaAdopcionMascotas.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Nombre { get; set; }

        [Range(0, 100, ErrorMessage = "La edad debe estar entre 0 y 100.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El tipo de mascota es obligatorio.")]
        public string? Tipo { get; set; }

        public bool Adoptada { get; set; }

        public Adoption? Adoption { get; set; }
    }
}
