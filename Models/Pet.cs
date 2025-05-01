using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SistemaAdopcionMascotas.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Range(0, 100)]
        public int Edad { get; set; }

        [Required]
        public string? Tipo { get; set; }

        public bool Adoptada { get; set; }

        public Adoption? Adoption { get; set; }
    }
}
