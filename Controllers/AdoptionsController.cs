using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAdopcionMascotas.Models;
using System.Linq;

namespace SistemaAdopcionMascotas.Controllers
{
    public class AdoptionsController : Controller
    {
        private readonly AppDbContext _context;

        public AdoptionsController(AppDbContext context)
        {
            _context = context;
        }

        // Mostrar formulario (si quieres usar formulario web, opcional)
        public IActionResult Assign()
        {
            var availablePets = _context.Pets.Where(p => !p.Adoptada).ToList();
            var adopters = _context.Adopters.ToList();

            ViewBag.Pets = availablePets;
            ViewBag.Adopters = adopters;

            return View();
        }

        // Procesar asignación
        [HttpPost]
        public IActionResult Assign(int petId, int adopterId)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.Id == petId);
            if (pet == null || pet.Adoptada)
            {
                return BadRequest("La mascota no existe o ya fue adoptada.");
            }

            var adoption = new Adoption
            {
                PetId = petId,
                AdopterId = adopterId
            };

            pet.Adoptada = true;

            _context.Adoptions.Add(adoption);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        // Listar adopciones como JSON
        public IActionResult List()
        {
            var adoptions = _context.Adoptions
                .Include(a => a.Pet)
                .Include(a => a.Adopter)
                .Select(a => new
                {
                    NombreMascota = a.Pet != null ? a.Pet.Nombre : "",
                    NombreAdoptante = a.Adopter != null ? a.Adopter.Nombre : "",
                    EstadoAdopcion = a.Pet != null && a.Pet.Adoptada ? "Adoptada" : "Disponible"
                })
                .ToList();

            return Json(adoptions);
        }
    }
}
