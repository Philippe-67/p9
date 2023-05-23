using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using p9.Models;

namespace p9.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Reparation> Reparations { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voiture>()
                .HasOne(v => v.Utilisateur)
                .WithMany(u => u.Voitures)
                .HasForeignKey(v => v.UtilisateurId);

            modelBuilder.Entity<Reparation>()
                .HasOne(r => r.Voiture)
                .WithMany(v => v.Reparations)
                .HasForeignKey(r => r.VoitureId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
