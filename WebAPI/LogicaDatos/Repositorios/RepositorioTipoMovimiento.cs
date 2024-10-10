using LogiaNegocio.Dominio;
using LogiaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaDatos.Repositorios
{
    public class RepositorioTipoMovimiento : IRepositorioTipoMovimiento
    {
        public DepositoContext Contexto { get; set; }
        public RepositorioTipoMovimiento(DepositoContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(TipoMovimiento obj)
        {
            if (obj == null) throw new DatosInvalidosException("Datos inválidos para nuevo alta.");
            TipoMovimiento t = BuscarPorNombre(obj.NombreTipoMovimiento.Valor);
            if(t != null) throw new DatosInvalidosException("El nombre que desea usar ya esta en uso.");
            Contexto.TiposMovimiento.Add(obj);
            Contexto.SaveChanges();
        }

        public TipoMovimiento BuscarPorNombre(string nombre)
        {
            return Contexto.TiposMovimiento.Where(tipoMov => tipoMov.NombreTipoMovimiento.Valor == nombre).SingleOrDefault();
        }

        public IEnumerable<TipoMovimiento> FindAll()
        {
            return Contexto.TiposMovimiento.ToList();
        }

        public TipoMovimiento FindById(int id)
        {
            TipoMovimiento tm = Contexto.TiposMovimiento.Where(tipoMov => tipoMov.Id == id).SingleOrDefault();
            if(tm == null) throw new DatosInvalidosException($"No existe tipo de movimiento con el Id: {id}");
            return tm;
        }

        public void Remove(int id)
        {
            if (Contexto.MovimientosStock.Any(ms => ms.TipoMovimiento.Id == id)) throw new DatosInvalidosException("El Tipo de Movimiento no se pudo eliminar porque esta en uso.");
            TipoMovimiento aBorrar = FindById(id);
            if (aBorrar != null)
            {
                Contexto.TiposMovimiento.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            else
            {
                throw new DatosInvalidosException("El Tipo de Movimiento no fue encontrado, no se pudo eliminar");
            }
        }

        public void Update(TipoMovimiento obj)
        {
            if (obj == null) throw new DatosInvalidosException("Los datos proporcionados no son validos");
            TipoMovimiento t = BuscarPorNombre(obj.NombreTipoMovimiento.Valor);
            if (t != null)
            {
                if (t.Id != obj.Id)
                {
                    throw new DatosInvalidosException("No se puede editar porque el nombre ya está en uso");
                }
                else
                {
                    Contexto.Entry(t).State = EntityState.Detached;
                }
            }
            else if (t == null)
            {
                throw new DatosInvalidosException("No se encontro el tipo de movimiento");
            }
            Contexto.TiposMovimiento.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
