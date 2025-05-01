using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SistemaAdopcionMascotas.Models
{
    public class Adopter
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Email { get; set; }

        public ICollection<Adoption> Adoptions { get; set; } = [];
    }
}
