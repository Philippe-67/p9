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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reparation>()
                .HasOne(r => r.Voiture)
                .WithMany(v => v.Reparations)
                .HasForeignKey(r => r.VoitureId);

           // base.OnModelCreating(modelBuilder);
        }
    }
}
