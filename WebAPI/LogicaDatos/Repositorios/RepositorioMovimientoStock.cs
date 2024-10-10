using LogiaNegocio.Dominio;
using LogiaNegocio.ExcepcionesPropias;
using LogiaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioMovimientoStock : IRepositorioMovimientosStock
    {
        DepositoContext Contexto { set; get; }

        public RepositorioMovimientoStock(DepositoContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(MovimientoStock obj)
        {
            if (obj == null) throw new DatosInvalidosException("El Movimiento de stock que se desea ingresar no es valido.");
            Usuario usu = Contexto.Usuarios.Where(u => u.Email.Valor == obj.UsuarioEmail && u is EncargadoDeposito).SingleOrDefault();
            if (usu == null) throw new DatosInvalidosException("El usuario que intenta ingresar el movimiento no esta habilitado");
            Contexto.Entry(obj.Articulo).State = EntityState.Unchanged;
            Contexto.Entry(obj.TipoMovimiento).State = EntityState.Unchanged;
            obj.Fecha = DateTime.Now;
            Contexto.MovimientosStock.Add(obj);
            Contexto.SaveChanges();
        }
        public IEnumerable<MovimientoStock> FindAll()
        {
            return Contexto.MovimientosStock.Include(mov => mov.Articulo).Include(mov => mov.TipoMovimiento).ToList();
        }
        public MovimientoStock FindById(int id)
        {
            MovimientoStock ms = Contexto.MovimientosStock.Where(mov => mov.Id == id)
                .Include(art => art.Articulo).SingleOrDefault();
            if (ms == null) throw new DatosInvalidosException("No se encontró el movimiento de stock.");
            return ms;
        }
        public void Remove(int id)
        {
            MovimientoStock aBorrar = FindById(id);
            if (aBorrar != null)
            {
                Contexto.MovimientosStock.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            else
            {
                throw new DatosInvalidosException("El Movimiento de Stock no fue encontrado, no se pudo eliminar");
            }
        }
        public void Update(MovimientoStock obj)
        {
            Contexto.MovimientosStock.Update(obj);
            Contexto.SaveChanges();
        }
        public IEnumerable<MovimientoStock> ObtenerMovimientosPorArticuloYTipo(int articuloId, int tipoMovimiento)
        {
            return Contexto.MovimientosStock
            .Where(m => m.Articulo.Id == articuloId && m.TipoMovimiento.Id == tipoMovimiento)
            .Include(m => m.Articulo)
            .Include(m => m.TipoMovimiento)
            .Distinct()
            .ToList();
        }
        public IEnumerable<MovimientoStock> ObtenerMovimientosPorArticuloYTipo(int articuloId, int tipoMovimiento, int pagina)
        {
            Parametro cantPaginas = Contexto.Parametros.Where(p => p.Nombre == "Paginacion").SingleOrDefault();
            return Contexto.MovimientosStock
            .Where(m => m.Articulo.Id == articuloId && m.TipoMovimiento.Id == tipoMovimiento)
            .Include(m => m.Articulo)
            .Include(m => m.TipoMovimiento)
            .Distinct().Skip((pagina - 1) * cantPaginas.Valor.Valor).Take(cantPaginas.Valor.Valor)
            .ToList();
        }
        public IEnumerable<MovimientoStock> ObtenerMovimientosPorRangoDeFechas(DateTime inicio, DateTime fin)
        {
            DateTime finArreglado = fin.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59).AddMicroseconds(59); //Para asegurar que se vea hasta la ultima consulta del dia indicado
            return Contexto.MovimientosStock
            .Where(m => m.Fecha >= inicio && m.Fecha <= finArreglado)
            .Include(m => m.Articulo)
            .Include(m => m.TipoMovimiento)
            .Distinct()
            .ToList();
        }
        public IEnumerable<MovimientoStock> ObtenerMovimientosPorRangoDeFechas(DateTime inicio, DateTime fin, int pagina)
        {
            Parametro cantPaginas = Contexto.Parametros.Where(p => p.Nombre == "Paginacion").SingleOrDefault();
            DateTime finArreglado = fin.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59).AddMicroseconds(59); //Para asegurar que se vea hasta la ultima consulta del dia indicado
            return Contexto.MovimientosStock
            .Where(m => m.Fecha >= inicio && m.Fecha <= finArreglado)
            .Include(m => m.Articulo)
            .Include(m => m.TipoMovimiento)
            .Distinct().Skip((pagina - 1) * cantPaginas.Valor.Valor).Take(cantPaginas.Valor.Valor)
            .ToList();
        }
        public string ObtenerResumenMovimientos()
        {
            int año = DateTime.Now.Year;
            var movimientosDelAño = Contexto.MovimientosStock
                .Where(m => m.Fecha.Year == año).Include(tm => tm.TipoMovimiento)
                .ToList();
            if (movimientosDelAño.Count == 0)
            {
                return $"No se encontraron movimientos para el año {año}.";
            }

            var resumen = $"Artículos Movidos para el año {año}:\n";

            var gruposPorTipo = movimientosDelAño
                .GroupBy(m => m.TipoMovimiento.Id);

            foreach (var grupo in gruposPorTipo)
            {
                var tipoMovimiento = grupo.FirstOrDefault().TipoMovimiento;
                var cantidadTotal = grupo.Sum(m => m.Cantidad.Valor);
                resumen += $"Tipo Movimiento: {tipoMovimiento.NombreTipoMovimiento.Valor} - Cantidad Unidades: {cantidadTotal}\n";
            }
            var totalAño = movimientosDelAño.Sum(m => m.Cantidad.Valor);
            resumen += $"Total de movimientos en {año}: {totalAño}";
            return resumen;
        }
        public double ObtenerCantidadPaginas(int totalMovimietos)
        {
            Parametro cantArticulosPorPagina = Contexto.Parametros.Where(p => p.Nombre == "Paginacion").SingleOrDefault();
            var resultado = Math.Ceiling(totalMovimietos / (double)cantArticulosPorPagina.Valor.Valor);
            return resultado;
        }
    }
}
