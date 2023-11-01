using Microsoft.EntityFrameworkCore;
using P1ProyectoAPI.Models;

namespace P1ProyectoAPI.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Plato> Menu { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<PlatoOrden> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plato>().HasData(
                    new Plato()
                    {
                        idPlato = 1,
                        nombre = "Chaulafan",
                        precio = 4.50,
                    },
                    new Plato()
                    {
                        idPlato = 2,
                        nombre = "Mixto",
                        precio = 6.00,

                    }
               );
            modelBuilder.Entity<Mesa>().HasData(
                    new Mesa()
                    {
                        idMesa = 1,
                        estado = false
                    },
                    new Mesa()
                    {
                        idMesa = 2,
                        estado = false
                    },
                    new Mesa()
                    {
                        idMesa = 3,
                        estado = false
                    },
                    new Mesa()
                    {
                        idMesa = 4,
                        estado = false
                    },
                    new Mesa()
                    {
                        idMesa = 5,
                        estado = false
                    },
                    new Mesa()
                    {
                        idMesa = 6,
                        estado = false
                    }
                );
        }
    }
}
