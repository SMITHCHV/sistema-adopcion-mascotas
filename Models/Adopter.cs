using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SistemaAdopcionMascotas.Models
{
    public class Adopter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del adoptante es obligatorio.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string? Email { get; set; }

        public ICollection<Adoption>? Adoptions { get; set; }
    }
}
