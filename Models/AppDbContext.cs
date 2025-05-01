using Microsoft.EntityFrameworkCore;

namespace SistemaAdopcionMascotas.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Adoption)
                .WithOne(a => a.Pet)
                .HasForeignKey<Adoption>(a => a.PetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Adoption>()
                .HasOne(a => a.Adopter)
                .WithMany(ad => ad.Adoptions)
                .HasForeignKey(a => a.AdopterId);

            modelBuilder.Entity<Adoption>()
                .HasIndex(a => a.PetId)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
