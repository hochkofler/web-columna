using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebColumnas.Models;

namespace WebColumnas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebColumnas.Models.Proveedor> Proveedor { get; set; } = default!;
        public DbSet<WebColumnas.Models.Marca> Marca { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>()
                .HasOne(b => b.Proveedor)
                .WithMany(a => a.Marcas)
                .HasForeignKey(b => b.ProveedorId);
        }
        public DbSet<WebColumnas.Models.FaseMovil> FaseMovil { get; set; } = default!;
        public DbSet<WebColumnas.Models.Columna> Columna { get; set; } = default!;
        public DbSet<WebColumnas.Models.Producto> Producto { get; set; } = default!;
        public DbSet<WebColumnas.Models.PrincipiosActivos> PrincipiosActivos { get; set; } = default!;
        public DbSet<WebColumnas.Models.ProductosPrincipios> ProductosPrincipios { get; set; } = default!;
        public DbSet<WebColumnas.Models.Lote> Lote { get; set; } = default!;
        public DbSet<WebColumnas.Models.Analisis> Analisis { get; set; } = default!;
    }
}
