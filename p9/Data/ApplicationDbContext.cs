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
        public DbSet <Voiture>Voitures { get; set; }
        public DbSet <Reparation> Reparations{ get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
    }
