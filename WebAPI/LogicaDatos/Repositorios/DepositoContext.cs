using LogiaNegocio.Dominio;
using LogiaNegocio.ValueObjects.TipoMovimiento;
using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class DepositoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MovimientoStock> MovimientosStock { get; set; }
        public DbSet<TipoMovimiento> TiposMovimiento { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DepositoContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Articulo
            modelBuilder.Entity<Articulo>()
                .OwnsOne(a => a.CodigoArticulo);
            modelBuilder.Entity<Articulo>()
               .OwnsOne(a => a.Descripcion);
            modelBuilder.Entity<Articulo>()
               .OwnsOne(a => a.Nombre);
            modelBuilder.Entity<Articulo>()
               .OwnsOne(a => a.Precio);
            modelBuilder.Entity<Articulo>()
               .OwnsOne(a => a.Stock);
            modelBuilder.Entity<Articulo>()
               .HasOne(a => a.Parametro)
               .WithOne()
               .HasForeignKey<Articulo>(a => a.ParametroId);

            //MovimientoStock
            modelBuilder.Entity<MovimientoStock>()
               .OwnsOne(m => m.Cantidad);
            modelBuilder.Entity<MovimientoStock>()
                   .HasOne(ms => ms.TipoMovimiento)
                   .WithMany(tm => tm.MovimientosStock)
                   .HasForeignKey(ms => ms.TipoMovimientoId);

            //Tipo de movimiento
            modelBuilder.Entity<TipoMovimiento>()
               .HasMany(t => t.MovimientosStock);
            modelBuilder.Entity<TipoMovimiento>()
               .OwnsOne(t => t.NombreTipoMovimiento);

            //Usuario
            modelBuilder.Entity<Usuario>()
               .HasDiscriminator<string>("TipoUsuario")
               .HasValue<Administrador>("Administrador")
               .HasValue<EncargadoDeposito>("EncargadoDeposito");
            modelBuilder.Entity<Usuario>()
               .OwnsOne(u => u.Email);
            modelBuilder.Entity<Usuario>()
               .OwnsOne(u => u.Nombre);
            modelBuilder.Entity<Usuario>()
               .OwnsOne(u => u.Apellido);
            modelBuilder.Entity<Usuario>()
               .OwnsOne(u => u.Contrasenia);

            //Parametro Articulo
            modelBuilder.Entity<Parametro>()
               .OwnsOne(pa => pa.Valor);



            base.OnModelCreating(modelBuilder);
        }
    }
}

