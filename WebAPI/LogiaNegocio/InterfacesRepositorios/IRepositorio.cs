using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T>
    {
        T FindById(int id);
        IEnumerable<T> FindAll();
        void Add(T obj);
        void Remove(int id);
        void Update(T obj);
    }
}
