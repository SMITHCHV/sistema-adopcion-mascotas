using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAdopcionMascotas.Models
{
    public class Adoption
    {
        public int Id { get; set; }

        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public Pet? Pet { get; set; }

        [ForeignKey("Adopter")]
        public int AdopterId { get; set; }
        public Adopter? Adopter { get; set; }
    }
}
