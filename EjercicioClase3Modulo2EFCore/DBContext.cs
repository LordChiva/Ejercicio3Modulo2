using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClase3Modulo2EFCore
{
    public class BDContext : DbContext
    {
        public DbSet<Actor> Actor { get; set; }

        public BDContext( DbContextOptions<BDContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().Property(prop => prop.NombreArtistico).HasColumnName("nombre_artistico");

            base.OnModelCreating(modelBuilder);
        }
    }
}
